﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql.Commands.Tree;

/// <summary>
/// Построитель команды дерева.
/// </summary>
public abstract class TreeCommandBuilder
{
    #region Properties

    /// <summary>
    /// Имя поля таблицы связи для идентификатора родителя.
    /// </summary>
    public string? LinkTableFieldNameForId { get; set; }

    /// <summary>
    /// Имя поля таблицы связи для идентификатора родителя.
    /// </summary>
    public string? LinkTableFieldNameForParentId { get; set; }

    /// <summary>
    /// Имя таблицы связи без схемы.
    /// </summary>
    public string? LinkTableNameWithoutSchema { get; set; }

    /// <summary>
    /// Схема таблицы связи.
    /// </summary>
    public string? LinkTableSchema { get; set; }

    /// <summary>
    /// Параметры.
    /// </summary>
    public TreeCommandParameters Parameters { get; private set; }
        = new TreeCommandParameters();

    /// <summary>
    /// Префикс.
    /// </summary>
    public string? Prefix { get; set; }

    /// <summary>
    /// SQL для запроса выборки идентификаторов.
    /// </summary>
    public string? SqlForIdsSelectQuery { get; set; }

    /// <summary>
    /// Имя поля таблицы дерева для идентификатора.
    /// </summary>
    public string? TreeTableFieldNameForId { get; set; }

    /// <summary>
    /// Имя поля таблицы дерева для идентификатора родителя.
    /// </summary>
    public string? TreeTableFieldNameForParentId { get; set; }

    /// <summary>
    /// Имя поля таблицы дерева для числа детей узла в дереве.
    /// </summary>
    public string? TreeTableFieldNameForTreeChildCount { get; set; }

    /// <summary>
    /// Имя поля таблицы дерева для числа потомков узла в дереве.
    /// </summary>
    public string? TreeTableFieldNameForTreeDescendantCount { get; set; }

    /// <summary>
    /// Имя поля таблицы дерева для уровня узла в дереве.
    /// </summary>
    public string? TreeTableFieldNameForTreeLevel { get; set; }

    /// <summary>
    /// Имя поля таблицы дерева для пути узла в дереве.
    /// </summary>
    public string? TreeTableFieldNameForTreePath { get; set; }

    /// <summary>
    /// Имя поля таблицы дерева для позиции узла в дереве.
    /// </summary>
    public string? TreeTableFieldNameForTreePosition { get; set; }

    /// <summary>
    /// Имя поля таблицы дерева для сортировки узла в дереве.
    /// </summary>
    public string? TreeTableFieldNameForTreeSort { get; set; }

    /// <summary>
    /// Имя таблицы дерева без схемы.
    /// </summary>
    public string? TreeTableNameWithoutSchema { get; set; }

    /// <summary>
    /// Схема таблицы дерева.
    /// </summary>
    public string? TreeTableSchema { get; set; }

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Получить результирующий SQL.
    /// </summary>
    public abstract string GetResultSql();

    #endregion Public methods
}
