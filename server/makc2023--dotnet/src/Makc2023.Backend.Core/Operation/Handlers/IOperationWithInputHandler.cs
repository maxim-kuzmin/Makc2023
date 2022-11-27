// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Core.Operation.Handlers;

/// <summary>
/// Интерфейс обработчика операции с входными данными.
/// </summary>
/// <typeparam name="TOperationInput">Тип входных данных операции.</typeparam>
public interface IOperationWithInputHandler<TOperationInput> : IOperationHandler
{
    #region Properties

    /// <summary>
    /// Входные данные операции.
    /// </summary>
    TOperationInput? OperationInput { get; }

    /// <summary>
    /// Результат выполнения операции.
    /// </summary>
    OperationResult? OperationResult { get; }

    #endregion Properties

    #region Methods

    /// <summary>
    /// Обработать начало.
    /// </summary>
    /// <param name="operationInput">Входные данные операции.</param>
    /// <param name="operationCode">Код операции.</param>
    void OnStart(TOperationInput operationInput, string? operationCode = null);

    /// <summary>
    /// Обработать успех.
    /// </summary>
    void OnSuccess();

    /// <summary>
    /// Обработать успех с результатом.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    void OnSuccessWithResult(OperationResult operationResult);

    #endregion Methods
}
