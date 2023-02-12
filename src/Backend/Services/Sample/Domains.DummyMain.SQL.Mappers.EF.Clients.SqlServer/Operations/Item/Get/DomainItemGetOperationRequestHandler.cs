// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Operations.Item.Get;

/// <summary>
/// Обработчик запроса операции получения элемента в домене.
/// </summary>
public class DomainItemGetOperationRequestHandler :
    IRequestHandler<DomainItemGetOperationRequest, DomainItemGetOperationResponse>
{
    #region Fields

    private readonly IDummyMainItemGetOperationHandler _operationHandler;

    private readonly IDummyMainRepository _repository;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationHandler">Обработчик операции.</param>
    /// <param name="repository">Репозиторий.</param>
    public DomainItemGetOperationRequestHandler(
        IDummyMainItemGetOperationHandler operationHandler,
        IDummyMainRepository repository)
    {
        _operationHandler = operationHandler;
        _repository = repository;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<DomainItemGetOperationResponse> Handle(
        DomainItemGetOperationRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            _operationHandler.OnStart(request.Input, request.OperationCode);

            var operationOutput = await _repository.GetItem(request.Input).ConfigureAwait(false);

            _operationHandler.OnSuccess(operationOutput);
        }
        catch (Exception ex)
        {
            _operationHandler.OnError(ex);
        }

        return new DomainItemGetOperationResponse(_operationHandler.OperationResult);
    }

    #endregion Public methods
}
