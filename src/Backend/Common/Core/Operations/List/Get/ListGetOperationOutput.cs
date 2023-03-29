// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.List.Get;

/// <summary>
/// Выходные данные операции получения списка.
/// </summary>
/// <typeparam name="TItem">Тип элемента.</typeparam>
/// <typeparam name="TTotalCount">Тип общего числа элементов.</typeparam>
public class ListGetOperationOutput<TItem, TTotalCount>
    where TItem : class
    where TTotalCount : struct
{
    #region Properties

    /// <summary>
    /// Элементы.
    /// </summary>
    public TItem[] Items { get; set; } = null!;

    /// <summary>
    /// Общее число элементов.
    /// </summary>
    public TTotalCount TotalCount { get; set; }

    #endregion Properties
}
