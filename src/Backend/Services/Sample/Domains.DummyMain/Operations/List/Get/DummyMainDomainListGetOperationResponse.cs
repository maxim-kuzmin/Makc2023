// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.List.Get;

/// <summary>
/// Отклик операции получения списка в домене "Фиктивное главное".
/// </summary>
public class DummyMainDomainListGetOperationResponse
{
    #region Properties

    /// <summary>
    /// Результат операции.
    /// </summary>
    public DummyMainDomainListGetOperationResult OperationResult { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    public DummyMainDomainListGetOperationResponse(DummyMainDomainListGetOperationResult operationResult)
    {
        OperationResult = operationResult;
    }

    #endregion Constructors
}
