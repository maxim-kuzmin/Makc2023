// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL;

/// <summary>
/// Инитерфейс ресурса.
/// </summary>
public interface IResource
{
    #region Methods

    /// <summary>
    /// Получить корректное значение свойства "Name".
    /// </summary>
    /// <returns>Корректное значение.</returns>
    string GetValidValueForName();

    #endregion Methods
}
