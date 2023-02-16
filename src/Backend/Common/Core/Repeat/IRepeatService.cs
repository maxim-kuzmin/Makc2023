// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Repeat;

/// <summary>
/// Интерфейс сервиса повторения.
/// </summary>
public interface IRepeatService
{
    #region Methods

    /// <summary>
    /// Выполнить.
    /// </summary>
    /// <param name="retryCount">Количество повторений.</param>
    /// <param name="actionToExecute">Выполняемое действие.</param>
    /// <param name="functionToFilterException">Функция для фильтрации исключений.</param>
    void Execute(
        int retryCount,
        Action actionToExecute,
        Func<Exception, bool>? functionToFilterException = null);

    /// <summary>
    /// Выполнить асинхронно.
    /// </summary>
    /// <param name="retryCount">Количество повторений.</param>
    /// <param name="functionToExecute">Выполняемая функция.</param>
    /// <param name="functionToFilterException">Функция для фильтрации исключений.</param>
    /// <returns>Задача на выполнение.</returns>
    Task ExecuteAsync(
        int retryCount,
        Func<Task> functionToExecute,
        Func<Exception, bool>? functionToFilterException = null);

    #endregion Methods
}
