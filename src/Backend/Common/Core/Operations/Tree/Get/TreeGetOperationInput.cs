// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Tree.Get;

/// <summary>
/// Входные данные операции получения дерева.
/// </summary>
public abstract class TreeGetOperationInput : ListGetOperationInput
{
    #region Properties

    /// <summary>
    /// Строка идентификаторов раскрытых узлов.
    /// </summary>
    public string ExpandedNodeIdsString { get; set; } = "";

    #endregion Properties
}
