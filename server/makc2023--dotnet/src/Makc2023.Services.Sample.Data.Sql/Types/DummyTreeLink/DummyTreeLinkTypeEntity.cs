// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyTreeLink;

/// <summary>
/// Сущность типа "Связь фиктивного дерева".
/// </summary>
public class DummyTreeLinkTypeEntity
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Идентификатор родителя.
    /// </summary>
    public long ParentId { get; set; }

    #endregion Properties
}
