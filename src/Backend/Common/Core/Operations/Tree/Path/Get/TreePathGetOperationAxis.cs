// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Tree.Path.Get;

/// <summary>
/// Ось операции получения ветви дерева.
/// </summary>
public enum TreePathGetOperationAxis
{
    /// <summary>
    /// Отсутствует.
    /// </summary>
    None = 0,
    /// <summary>
    /// Все.
    /// </summary>
    All = 1,
    /// <summary>
    /// Предок.
    /// </summary>
    Ancestor = 2,
    /// <summary>
    /// Предок или корневой узел.
    /// </summary>
    AncestorOrSelf = 3,
    /// <summary>
    /// Ребёнок.
    /// </summary>
    Child = 4,
    /// <summary>
    /// Ребёнок или корневой узел.
    /// </summary>
    ChildOrSelf = 5,
    /// <summary>
    /// Потомок.
    /// </summary>
    Descendant = 6,
    /// <summary>
    /// Потомок или корневой узел.
    /// </summary>
    DescendantOrSelf = 7,
    /// <summary>
    /// Родитель или корневой узел.
    /// </summary>
    ParentOrSelf = 8
}
