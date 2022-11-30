// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Domain.Sql.Mappers.EF.Mediator.Behaviors;

public class MapperMediatorTransactionBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    #region Properties

    private IMapperDbManager DbManager { get; init; }

    private IIntegrationService IntegrationService { get; init; }

    private ILogger Logger { get; init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbManager">Менеджер базы данных.</param>
    /// <param name="integrationService">Сервис интеграции.</param>
    /// <param name="logger">Регистратор.</param>
    public MapperMediatorTransactionBehavior(
        IMapperDbManager dbManager,
        IIntegrationService integrationService,
        ILogger<MapperMediatorTransactionBehavior<TRequest, TResponse>> logger)
    {
        DbManager = dbManager;
        IntegrationService = integrationService;
        Logger = logger;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var response = default(TResponse)!;

        string typeName = request.GetGenericTypeName();

        try
        {
            if (DbManager.HasTransaction || !DbManager.IsUsed)
            {
                return await next();
            }

            var strategy = DbManager.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                Guid transactionId;

                await using var transaction = (await DbManager.BeginTransactionAsync())!;

                using (Logger.BeginScope("TransactionContext {TransactionId}", transaction.TransactionId))
                {
                    Logger.LogInformation(
                        "----- Begin transaction {TransactionId} for {CommandName} ({@Command})",
                        transaction.TransactionId,
                        typeName,
                        request);

                    response = await next();

                    Logger.LogInformation(
                        "----- Commit transaction {TransactionId} for {CommandName}",
                        transaction.TransactionId,
                        typeName);

                    await DbManager.CommitTransactionAsync(transaction);

                    transactionId = transaction.TransactionId;
                }

                await IntegrationService.PublishEvents(transactionId);
            });

            return response;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

            throw;
        }
    }

    #endregion Public methods
}
