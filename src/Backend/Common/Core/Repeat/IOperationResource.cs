// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Repeat;

/// <summary>
/// Интерфейс ресурса повторения.
/// </summary>
public interface IRepeatResource
{
    #region Methods

    /// <summary>
    /// Получить сообщение об ошибке для повторной попытки.
    /// </summary>
    /// <param name="exception">Исключение.</param>
    /// <param name="retryNumber">Номер повторения.</param>
    /// <param name="retryCount">Количество повторений.</param>    
    /// <returns>Сообщение об ошибке.</returns>
    string GetErrorMessageForRetry(Exception exception, int retryNumber, int retryCount);

    #endregion Methods
}
