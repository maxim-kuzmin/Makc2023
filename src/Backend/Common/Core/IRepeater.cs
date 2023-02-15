// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core;

/// <summary>
/// Интерфейс повторителя.
/// </summary>
public interface IRepeater
{
    #region Methods

    /// <summary>
    /// Выполнить.
    /// </summary>
    /// <typeparam name="TException">Тип исключения.</typeparam>
    /// <param name="retries">Количество повторений.</param>
    /// <param name="actionToExecute">Выполняемое действие.</param>
    void Execute<TException>(int retries, Action actionToExecute) where TException : Exception;

    /// <summary>
    /// Выполнить асинхронно.
    /// </summary>
    /// <typeparam name="TException">Тип исключения.</typeparam>
    /// <param name="retries">Количество повторений.</param>
    /// <param name="functionToExecute">Выполняемая функция.</param>
    /// <returns>Задача на выполнение.</returns>
    public Task ExecuteAsync<TException>(int retries, Func<Task> functionToExecute) where TException : Exception;

    #endregion Methods
}
