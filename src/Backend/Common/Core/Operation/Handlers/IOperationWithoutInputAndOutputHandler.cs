// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation.Handlers;

/// <summary>
/// Интерфейс обработчика операции без входных и выходных данных.
/// </summary>
/// <typeparam name="TOperationResult">Тип результата операции.</typeparam>
public interface IOperationWithoutInputAndOutputHandler<TOperationResult> : IOperationHandler
    where TOperationResult : OperationResult, new()
{
    #region Properties

    /// <summary>
    /// Результат выполнения операции.
    /// </summary>
    TOperationResult OperationResult { get; }

    #endregion Properties

    #region Methods

    /// <summary>
    /// Обработать начало.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    void HandleStart(string operationCode = "");

    /// <summary>
    /// Обработать успех.
    /// </summary>
    public void HandleSuccess();

    /// <summary>
    /// Обработать успех с результатом.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    void HandleSuccessWithResult(TOperationResult operationResult);

    #endregion Methods
}
