// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Core.Converting;

/// <summary>
/// Интерфейс ресурса преобразования.
/// </summary>
public interface IConvertingResource
{
    #region Methods

    /// <summary>
    /// Получить формат для даты.
    /// </summary>
    /// <returns>Формат.</returns>
    string GetFormatForDate();

    #endregion Methods
}
