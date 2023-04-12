// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation.Handlers;

/// <summary>
/// Интерфейс обработчика операции с входными данными.
/// </summary>
/// <typeparam name="TOperationInput">Тип входных данных операции.</typeparam>
/// <typeparam name="TOperationResult">Тип результата операции.</typeparam>
public interface IOperationWithInputHandler<TOperationInput, TOperationResult> : IOperationHandler
    where TOperationResult : OperationResult, new()
{
    #region Properties

    /// <summary>
    /// Входные данные операции.
    /// </summary>
    TOperationInput OperationInput { get; }

    /// <summary>
    /// Результат выполнения операции.
    /// </summary>
    TOperationResult OperationResult { get; }

    #endregion Properties

    #region Methods

    /// <summary>
    /// Обработать начало.
    /// </summary>
    /// <param name="operationInput">Входные данные операции.</param>
    /// <param name="operationCode">Код операции.</param>
    void HandleStart(TOperationInput operationInput, string operationCode = "");

    /// <summary>
    /// Обработать успех.
    /// </summary>
    void HandleSuccess();

    /// <summary>
    /// Обработать успех с результатом.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    void HandleSuccessWithResult(TOperationResult operationResult);

    #endregion Methods
}
