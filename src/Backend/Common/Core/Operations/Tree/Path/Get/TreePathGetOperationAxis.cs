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
    None = 1,
    /// <summary>
    /// Все.
    /// </summary>
    All = 2,
    /// <summary>
    /// Предок.
    /// </summary>
    Ancestor = 3,
    /// <summary>
    /// Предок или корневой узел.
    /// </summary>
    AncestorOrSelf = 4,
    /// <summary>
    /// Ребёнок.
    /// </summary>
    Child = 5,
    /// <summary>
    /// Ребёнок или корневой узел.
    /// </summary>
    ChildOrSelf = 6,
    /// <summary>
    /// Потомок.
    /// </summary>
    Descendant = 7,
    /// <summary>
    /// Потомок или корневой узел.
    /// </summary>
    DescendantOrSelf = 8,
    /// <summary>
    /// Родитель или корневой узел.
    /// </summary>
    ParentOrSelf = 9
}
