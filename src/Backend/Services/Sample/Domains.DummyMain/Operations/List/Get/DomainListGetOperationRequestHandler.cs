// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.List.Get;

/// <summary>
/// Обработчик запроса операции получения списка в домене.
/// </summary>
public class DomainListGetOperationRequestHandler :
    IRequestHandler<DomainListGetOperationRequest, DomainListGetOperationResponse>
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
    public DomainListGetOperationRequestHandler(
        IDummyMainItemGetOperationHandler operationHandler,
        IDummyMainRepository repository)
    {
        _operationHandler = operationHandler;
        _repository = repository;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<DomainListGetOperationResponse> Handle(
        DomainListGetOperationRequest request,
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

        return new DomainListGetOperationResponse(_operationHandler.OperationResult);
    }

    #endregion Public methods
}
