// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Tree.Get;

/// <summary>
/// Выходные данные операции получения дерева.
/// </summary>
/// <typeparam name="TNode">Тип узла.</typeparam>
public class ItemGetOperationOutput<TNode>
   where TNode : class
{
    #region Properties

    /// <summary>
    /// Узлы.
    /// </summary>
    public TNode[] Nodes { get; set; } = null!;

    #endregion Properties
}
