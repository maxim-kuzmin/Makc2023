// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Commands.Tree.Trigger;

/// <summary>
/// Построитель команды на срабатывание триггера дерева.
/// </summary>
public abstract class TreeTriggerCommandBuilder : TreeCommandBuilder
{
    #region Properties

    /// <summary>
    /// Действие.
    /// </summary>
    public TriggerCommandAction Action { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    public TreeTriggerCommandBuilder()
    {
        Prefix = "TreeTrigger_";
    }

    #endregion Constructors
}
