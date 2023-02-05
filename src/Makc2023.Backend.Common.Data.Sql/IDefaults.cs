// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.Sql;

/// <summary>
/// Интерфейс значений по умолчанию.
/// </summary>
public interface IDefaults
{
    #region Properties

    /// <summary>
    /// Колонка в базе данных для поля "Id".
    /// </summary>
    string DbColumnForId { get; }

    /// <summary>
    /// Колонка в базе данных для поля "Name".
    /// </summary>
    string DbColumnForName { get; }

    /// <summary>
    /// Колонка в базе данных для поля "ParentId".
    /// </summary>
    string DbColumnForParentId { get; }

    /// <summary>
    /// Колонка в базе данных для поля "TreeChildCount".
    /// </summary>
    string DbColumnForTreeChildCount { get; }

    /// <summary>
    /// Колонка в базе данных для поля "TreeDescendantCount".
    /// </summary>
    string DbColumnForTreeDescendantCount { get; }

    /// <summary>
    /// Колонка в базе данных для поля "TreeLevel".
    /// </summary>
    string DbColumnForTreeLevel { get; }

    /// <summary>
    /// Колонка в базе данных для поля "TreePath".
    /// </summary>
    string DbColumnForTreePath { get; }

    /// <summary>
    /// Колонка в базе данных для поля "TreePosition".
    /// </summary>
    string DbColumnForTreePosition { get; }

    /// <summary>
    /// Колонка в базе данных для поля "TreeSort".
    /// </summary>
    string DbColumnForTreeSort { get; }

    /// <summary>
    /// Разделитель частей имени колонки в базе данных.
    /// </summary>
    string DbColumnPartsSeparator { get; }

    /// <summary>
    /// Префикс внешнего ключа в базе данных.
    /// </summary>
    string DbForeignKeyPrefix { get; }

    /// <summary>
    /// Префикс индекса в базе данных.
    /// </summary>
    string DbIndexPrefix { get; }

    /// <summary>
    /// Префикс первичного ключа в базе данных.
    /// </summary>
    string DbPrimaryKeyPrefix { get; }

    /// <summary>
    /// Схема в базе данных.
    /// </summary>
    string DbSchema { get; }

    /// <summary>
    /// Префикс уникального индекса в базе данных.
    /// </summary>
    string DbUniqueIndexPrefix { get; }

    /// <summary>
    /// Разделитель частей полного имени.
    /// </summary>
    string FullNamePartsSeparator { get; }

    /// <summary>
    /// Разделитель частей имени.
    /// </summary>
    string NamePartsSeparator { get; }

    #endregion Properties
}
