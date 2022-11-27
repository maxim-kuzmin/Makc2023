// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Core.Operation.Handlers;

/// <summary>
/// Интерфейс обработчика операции с выходными данными.
/// </summary>
/// <typeparam name="TOperationOutput">Тип выходных данных операции.</typeparam>    
public interface IOperationWithOutputHandler<TOperationOutput> : IOperationHandler
{
    #region Properties

    /// <summary>
    /// Результат выполнения операции.
    /// </summary>
    OperationResultWithOutput<TOperationOutput>? OperationResult { get; }

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Обработать начало.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    void OnStart(string? operationCode = null);

    /// <summary>
    /// Обработать успех.
    /// </summary>
    /// <param name="operationOutput">Выходные данные операции.</param>
    void OnSuccess(TOperationOutput operationOutput);

    /// <summary>
    /// Обработать успех с результатом.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    void OnSuccessWithResult(OperationResultWithOutput<TOperationOutput> operationResult);

    #endregion Public methods
}
