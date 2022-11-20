// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Operation;

/// <summary>
/// Интерфейс обработчика операции.
/// </summary>
public interface IOperationHandler
{
    #region Methods

    /// <summary>
    /// Обработать ошибку.
    /// </summary>
    /// <param name="exception">Исключение.</param>
    void OnError(Exception exception);

    #endregion Methods
}
