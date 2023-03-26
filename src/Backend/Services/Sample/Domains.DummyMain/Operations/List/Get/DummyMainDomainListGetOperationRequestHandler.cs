// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.List.Get;

/// <summary>
/// Обработчик запроса операции получения списка в домене "Фиктивное главное".
/// </summary>
public class DummyMainDomainListGetOperationRequestHandler :
    IRequestHandler<DummyMainDomainListGetOperationRequest, DummyMainDomainListGetOperationResponse>
{
    #region Fields

    private readonly IDummyMainDomainListGetOperationHandler _operationHandler;

    private readonly IDummyMainDomainRepository _repository;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationHandler">Обработчик операции.</param>
    /// <param name="repository">Репозиторий.</param>
    public DummyMainDomainListGetOperationRequestHandler(
        IDummyMainDomainListGetOperationHandler operationHandler,
        IDummyMainDomainRepository repository)
    {
        _operationHandler = operationHandler;
        _repository = repository;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<DummyMainDomainListGetOperationResponse> Handle(
        DummyMainDomainListGetOperationRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            _operationHandler.HandleStart(request.Input, request.OperationCode);

            var operationOutput = await _repository.GetList(request.Input).ConfigureAwait(false);

            _operationHandler.HandleSuccess(operationOutput);
        }
        catch (Exception ex)
        {
            _operationHandler.HandleError(ex);
        }

        return new DummyMainDomainListGetOperationResponse(_operationHandler.OperationResult);
    }

    #endregion Public methods
}
