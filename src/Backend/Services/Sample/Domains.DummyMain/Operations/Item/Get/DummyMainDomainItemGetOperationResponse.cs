// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Отклик операции получения элемента в домене.
/// </summary>
public class DummyMainDomainItemGetOperationResponse
{
    #region Properties

    /// <summary>
    /// Результат операции.
    /// </summary>
    public DummyMainItemGetOperationResult OperationResult { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    public DummyMainDomainItemGetOperationResponse(DummyMainItemGetOperationResult operationResult)
    {
        OperationResult = operationResult;
    }

    #endregion Constructors
}
