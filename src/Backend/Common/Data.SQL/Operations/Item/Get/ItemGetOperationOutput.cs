// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Operations.Item.Get;

/// <summary>
/// Выходные данные операции получения элемента.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class ItemGetOperationOutput<TEntity>
    where TEntity : class
{
    #region Properties

    /// <summary>
    /// Сущность.
    /// </summary>
    public TEntity Entity { get; set; } = null!;

    /// <summary>
    /// Признак того, что сущность не найдена.
    /// </summary>
    public bool IsEntityNotFound { get; set; }

    #endregion Properties
}
