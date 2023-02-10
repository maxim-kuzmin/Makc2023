// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.SQL.Mappers.EF.Mediator.Behaviors;

public class MapperMediatorTransactionBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    #region Fields

    private readonly IMapperDbManager _dbManager;

    private readonly IIntegrationService _integrationService;

    private readonly ILogger _logger;

    #endregion Fields

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
        _dbManager = dbManager;
        _integrationService = integrationService;
        _logger = logger;
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
            if (_dbManager.HasTransaction || !_dbManager.IsUsed)
            {
                return await next().ConfigureAwait(false);
            }

            var strategy = _dbManager.CreateExecutionStrategy();

            var taskForTransaction = strategy.ExecuteAsync(async () =>
            {
                Guid transactionId;

                await using var transaction = (await _dbManager.BeginTransactionAsync().ConfigureAwait(false))!;

                using (_logger.BeginScope("TransactionContext {TransactionId}", transaction.TransactionId))
                {
                    _logger.LogInformation(
                        "----- Begin transaction {TransactionId} for {CommandName} ({@Command})",
                        transaction.TransactionId,
                        typeName,
                        request);

                    response = await next().ConfigureAwait(false);

                    _logger.LogInformation(
                        "----- Commit transaction {TransactionId} for {CommandName}",
                        transaction.TransactionId,
                        typeName);

                    await _dbManager.CommitTransactionAsync(transaction).ConfigureAwait(false);

                    transactionId = transaction.TransactionId;
                }

                await _integrationService.PublishEvents(transactionId).ConfigureAwait(false);
            });

            await taskForTransaction.ConfigureAwait(false);

            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

            throw;
        }
    }

    #endregion Public methods
}
