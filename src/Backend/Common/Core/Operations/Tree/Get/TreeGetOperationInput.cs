// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Tree.Get;

/// <summary>
/// Входные данные операции получения дерева.
/// </summary>
public abstract class TreeGetOperationInput : ListGetOperationInput
{
    #region Properties

    /// <summary>
    /// Ось.
    /// </summary>
    public TreeGetOperationAxisForList Axis { get; set; }

    /// <summary>
    /// Строка идентификаторов раскрытых узлов.
    /// </summary>
    public string ExpandedNodeIdsString { get; set; } = "";

    /// <summary>
    /// Путь в дереве корневого узла.
    /// </summary>
    public string RootNodeTreePath { get; set; } = "";

    #endregion Properties

    #region Public methods

    /// <inheritdoc/>
    public override void Normalize()
    {
        base.Normalize();

        if (Axis == TreeGetOperationAxisForList.None)
        {
            Axis = TreeGetOperationAxisForList.All;
        }
    }

    #endregion Public methods
}
