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
    /// Узел к идентификатору.
    /// </summary>
    public DummyTreeEntity? NodeToId { get; set; }

    /// <summary>
    /// Узел к идентификатору родителя.
    /// </summary>
    public DummyTreeEntity? NodeToParentId { get; set; }

    #endregion Navigation properties
}
