// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Tree.Get.Inputs;

/// <summary>
/// Входные данные операции получения дерева с 64-битным целочисленным идентификатором узла.
/// </summary>
public class TreeGetOperationInputWithInt64NodeId : TreeGetOperationInput
{
    #region Properties

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
    }

    #endregion Public methods
}
