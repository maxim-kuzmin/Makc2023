// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Operations.Item.Get;

/// <summary>
/// Выходные данные операции получения элемента.
/// </summary>
/// <typeparam name="TItem">Элемент.</typeparam>
public class ItemGetOperationOutput<TItem>
   where TItem : class
{
    #region Properties

    /// <summary>
    /// Элемент.
    /// </summary>
    public TItem Item { get; set; } = null!;

    /// <summary>
    /// Признак того, что элемент не найден.
    /// </summary>
    public bool IsItemNotFound { get; set; }

    #endregion Properties
}
