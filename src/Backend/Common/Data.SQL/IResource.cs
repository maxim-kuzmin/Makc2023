// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL;

/// <summary>
/// Инитерфейс ресурса.
/// </summary>
public interface IResource
{
    #region Methods

    /// <summary>
    /// Получить корректное значение свойства "Id".
    /// </summary>
    /// <returns>Корректное значение.</returns>
    string GetValidValueForId();

    /// <summary>
    /// Получить корректное значение свойства "SortField".
    /// </summary>
    /// <param name="asc">Вариант значения по возрастанию.</param>
    /// <param name="desc">Вариант значения по убыванию.</param>
    /// <returns>Корректое значение.</returns>
    string GetValidValueForSortField(string asc, string desc);

    #endregion Methods
}
