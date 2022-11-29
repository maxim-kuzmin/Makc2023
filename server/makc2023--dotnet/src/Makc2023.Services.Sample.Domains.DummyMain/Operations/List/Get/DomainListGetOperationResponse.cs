// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain.Operations.List.Get;

/// <summary>
/// Отклик операции получения списка в домене.
/// </summary>
public class DomainListGetOperationResponse
{
    #region Properties

    /// <summary>
    /// Результат операции.
    /// </summary>
    public OperationResultWithOutput<DummyMainItemGetOperationOutput>? OperationResult { get; init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    public DomainListGetOperationResponse(
        OperationResultWithOutput<DummyMainItemGetOperationOutput>? operationResult)
    {
        OperationResult = operationResult;
    }

    #endregion Constructors
}
