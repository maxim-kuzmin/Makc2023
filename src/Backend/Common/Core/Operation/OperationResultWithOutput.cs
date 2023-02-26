// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation;

/// <summary>
/// Результат операции с выходными данными.
/// </summary>
/// <typeparam name="TOutput">Тип выходных данных.</typeparam>
public class OperationResultWithOutput<TOutput> : OperationResult
    where TOutput: class, new()
{
    #region Properties

    /// <summary>
    /// Выходные данные.
    /// </summary>
    public TOutput Output { get; set; } = null!;

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Загрузить с выходными данными.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    public void LoadWithOutput(OperationResultWithOutput<TOutput> operationResult)
    {
        Load(operationResult);

        Output = operationResult.Output;
    }

    #endregion Public methods
}
