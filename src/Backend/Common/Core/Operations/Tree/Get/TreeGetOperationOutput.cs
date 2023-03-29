// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Tree.Get;

/// <summary>
/// Выходные данные операции получения дерева.
/// </summary>
/// <typeparam name="TNode">Тип узла.</typeparam>
/// <typeparam name="TTotalCount">Тип общего числа узлов.</typeparam>
public class TreeGetOperationOutput<TNode, TTotalCount>
   where TNode : class
   where TTotalCount : struct
{
    #region Properties

    /// <summary>
    /// Узлы.
    /// </summary>
    public TNode[] Nodes { get; set; } = null!;

    /// <summary>
    /// Общее число узлов.
    /// </summary>
    public TTotalCount TotalCount { get; set; }

    #endregion Properties
}
