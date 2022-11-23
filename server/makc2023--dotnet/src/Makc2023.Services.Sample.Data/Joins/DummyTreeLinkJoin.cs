// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Joins;

/// <summary>
/// Соединение "Связь фиктивного дерева".
/// </summary>
public class DummyTreeLinkJoin
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; private set; }

    /// <summary>
    /// Идентификатор родителя.
    /// </summary>
    public long ParentId { get; private set; }

    #endregion Properties

    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Фиктивное дерево" по идентификатору.
    /// </summary>
    public DummyTreeEntity? DummyTreeById { get; set; }

    /// <summary>
    /// Экземпляр сущности "Фиктивное дерево" по идентификатору родителя.
    /// </summary>
    public DummyTreeEntity? DummyTreeByParentId { get; set; }

    #endregion Navigation properties
}
