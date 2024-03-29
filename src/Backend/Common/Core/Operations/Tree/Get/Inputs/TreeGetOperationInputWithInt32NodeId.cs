﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Tree.Get.Inputs;

/// <summary>
/// Входные данные операции получения дерева с 32-битным целочисленным идентификатором узла.
/// </summary>
public class TreeGetOperationInputWithInt32NodeId : TreeGetOperationInput
{
    #region Properties

    /// <summary>
    /// Идентификатор раскрытого узла.
    /// </summary>
    public int ExpandedNodeId { get; set; }

    /// <summary>
    /// Идентификаторы раскрытых узлов.
    /// </summary>
    public int[] ExpandedNodeIds { get; set; } = Array.Empty<int>();

    /// <summary>
    /// Идентификатор корневого узла.
    /// </summary>
    public int RootNodeId { get; set; }

    #endregion Properties

    #region Public methods

    /// <inheritdoc/>
    public override void Normalize()
    {
        base.Normalize();

        if (RootNodeId < 0)
        {
            RootNodeId = 0;
        }

        if (ExpandedNodeId < 0)
        {
            ExpandedNodeId = 0;
        }

        if (!string.IsNullOrWhiteSpace(ExpandedNodeIdsString) && !ExpandedNodeIds.Any())
        {
            ExpandedNodeIds = ExpandedNodeIdsString.FromStringToNumericInt32Array();
        }

        if (string.IsNullOrWhiteSpace(RootNodeTreePath) || RootNodeId < 1)
        {
            if (Axis == TreeGetOperationAxisForList.ChildOrSelf)
            {
                Axis = TreeGetOperationAxisForList.Child;
            }
        }
    }

    #endregion Public methods
}
