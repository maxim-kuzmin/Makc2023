// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql.Commands.Tree.Calculate;

/// <summary>
/// Построитель команды на вычисление дерева.
/// </summary>
public abstract class TreeCalculateCommandBuilder : TreeCommandBuilder
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    public TreeCalculateCommandBuilder()
    {
        Prefix = "TreeCalculate_";
    }

    #endregion Constructors
}
