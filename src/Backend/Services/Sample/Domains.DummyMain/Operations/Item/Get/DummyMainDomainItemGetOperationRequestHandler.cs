// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Обработчик запроса операции получения элемента в домене.
/// </summary>
public class DummyMainDomainItemGetOperationRequestHandler :
    IRequestHandler<DummyMainDomainItemGetOperationRequest, DummyMainDomainItemGetOperationResponse>
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
    public DummyMainDomainItemGetOperationRequestHandler(
        IDummyMainItemGetOperationHandler operationHandler,
        IDummyMainRepository repository)
    {
        _operationHandler = operationHandler;
        _repository = repository;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<DummyMainDomainItemGetOperationResponse> Handle(
        DummyMainDomainItemGetOperationRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            _operationHandler.HandleStart(request.Input, request.OperationCode);

            var operationOutput = await _repository.GetItem(request.Input).ConfigureAwait(false);

            _operationHandler.HandleSuccess(operationOutput);
        }
        catch (Exception ex)
        {
            _operationHandler.HandleError(ex);
        }

        return new DummyMainDomainItemGetOperationResponse(_operationHandler.OperationResult);
    }

    #endregion Public methods
}
