// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations;

/// <summary>
/// Интерфейс ресурса операций.
/// </summary>
public interface IOperationsResource
{
    #region Methods

    /// <summary>
    /// Получить корректное значение свойства "Id" входных данных операции.
    /// </summary>
    /// <returns>Корректное значение.</returns>
    string GetOperationInputValidValueForId();

    /// <summary>
    /// Получить корректное значение свойства "SortField" входных данных операции.
    /// </summary>
    /// <param name="asc">Вариант значения по возрастанию.</param>
    /// <param name="desc">Вариант значения по убыванию.</param>
    /// <returns>Корректое значение.</returns>
    string GetOperationInputValidValueForSortField(string asc, string desc);

    #endregion Methods
}
