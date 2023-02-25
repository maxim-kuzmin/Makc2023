// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Operations.DummyMain.Item.Get;

/// <summary>
/// Результат операции получения элемента "Фиктивное главное".
/// </summary>
public class DummyMainItemGetOperationResult : OperationResultWithOutput<DummyMainItemGetOperationOutput>
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    public DummyMainItemGetOperationResult(OperationResultWithOutput<DummyMainItemGetOperationOutput> operationResult)
    {
        IsOk = operationResult.IsOk;

        OperationCode = operationResult.OperationCode;

        Output = operationResult.Output;

        foreach (string errorMessage in operationResult.ErrorMessages)
        {
            ErrorMessages.Add(errorMessage);
        }
    }

    #endregion Constructors
}
