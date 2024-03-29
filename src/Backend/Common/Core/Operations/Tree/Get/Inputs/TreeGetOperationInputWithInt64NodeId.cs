﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Tree.Get.Inputs;

/// <summary>
/// Входные данные операции получения дерева с 64-битным целочисленным идентификатором узла.
/// </summary>
public class TreeGetOperationInputWithInt64NodeId : TreeGetOperationInput
{
    #region Properties

    /// <summary>
    /// Идентификатор раскрытого узла.
    /// </summary>
    public long ExpandedNodeId { get; set; }

    /// <summary>
    /// Идентификаторы раскрытых узлов.
    /// </summary>
    public long[] ExpandedNodeIds { get; set; } = Array.Empty<long>();

    /// <summary>
    /// Идентификатор корневого узла.
    /// </summary>
    public long RootNodeId { get; set; }

    #endregion Properties

    #region Public methods

    /// <inheritdoc/>
    public override void Normalize()
    {
        base.Normalize();

        if (RootNodeId < 0L)
        {
            RootNodeId = 0L;
        }

        if (ExpandedNodeId < 0L)
        {
            ExpandedNodeId = 0L;
        }

        if (!string.IsNullOrWhiteSpace(ExpandedNodeIdsString) && !ExpandedNodeIds.Any())
        {
            ExpandedNodeIds = ExpandedNodeIdsString.FromStringToNumericInt64Array();
        }

        if (string.IsNullOrWhiteSpace(RootNodeTreePath) || RootNodeId < 1L)
        {
            if (Axis == TreeGetOperationAxisForList.ChildOrSelf)
            {
                Axis = TreeGetOperationAxisForList.Child;
            }
        }
    }

    #endregion Public methods
}
