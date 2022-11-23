// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyTree;

/// <summary>
/// Параметры типа "Фиктивное дерево".
/// </summary>
public class DummyTreeTypeOptions : TypeOptions
{
    #region Properties

    /// <summary>
    /// Колонка в базе данных для поля "Id".
    /// </summary>
    public string? DbColumnForId { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "Name".
    /// </summary>
    public string? DbColumnForName { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "ParentId".
    /// </summary>
    public string? DbColumnForParentId { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "TreeChildCount".
    /// </summary>
    public string? DbColumnForTreeChildCount { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "TreeDescendantCount".
    /// </summary>
    public string? DbColumnForTreeDescendantCount { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "TreeLevel".
    /// </summary>
    public string? DbColumnForTreeLevel { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "TreePath".
    /// </summary>
    public string? DbColumnForTreePath { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "TreePosition".
    /// </summary>
    public string? DbColumnForTreePosition { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "TreeSort".
    /// </summary>
    public string? DbColumnForTreeSort { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к родительскому типу "Фиктивное дерево".
    /// </summary>
    public string? DbForeignKeyToDummyTreeParent { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля "Name".
    /// </summary>
    public string? DbIndexForName { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля "ParentId".
    /// </summary>
    public string? DbIndexForParentId { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля "TreeSort".
    /// </summary>
    public string? DbIndexForTreeSort { get; set; }

    /// <summary>
    /// Максимальная длина в базе данных для поля "Name".
    /// </summary>
    public int DbMaxLengthForName { get; set; }

    /// <summary>
    /// Максимальная длина в базе данных для поля "TreePath".
    /// </summary>
    public int DbMaxLengthForTreePath { get; set; }

    /// <summary>
    /// Максимальная длина в базе данных для поля "TreeSort".
    /// </summary>
    public int DbMaxLengthForTreeSort { get; set; }

    /// <summary>
    /// Первичный ключ в базе данных.
    /// </summary>
    public string? DbPrimaryKey { get; set; }

    /// <summary>
    /// Индекс в базе данных для полей "ParentId" и "Name".
    /// </summary>
    public string? DbUniqueIndexForParentIdAndName { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public DummyTreeTypeOptions(
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        DbColumnForId = defaults.DbColumnForId;

        if (string.IsNullOrWhiteSpace(defaults.DbColumnForName))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyTreeTypeOptions>(
                nameof(defaults),
                nameof(defaults.DbColumnForName));
        }

        DbColumnForName = defaults.DbColumnForName;

        if (string.IsNullOrWhiteSpace(defaults.DbColumnForParentId))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyTreeTypeOptions>(
                nameof(defaults),
                nameof(defaults.DbColumnForParentId));
        }

        DbColumnForParentId = defaults.DbColumnForParentId;

        DbColumnForTreeChildCount = defaults.DbColumnForTreeChildCount;

        DbColumnForTreeDescendantCount = defaults.DbColumnForTreeDescendantCount;

        DbColumnForTreeLevel = defaults.DbColumnForTreeLevel;

        DbColumnForTreePath = defaults.DbColumnForTreePath;

        DbColumnForTreePosition = defaults.DbColumnForTreePosition;

        if (string.IsNullOrWhiteSpace(defaults.DbColumnForTreeSort))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyTreeTypeOptions>(
                nameof(defaults),
                nameof(defaults.DbColumnForTreeSort));
        }

        DbColumnForTreeSort = defaults.DbColumnForTreeSort;

        DbForeignKeyToDummyTreeParent = CreateDbForeignKeyName(DbTable, DbTable, DbColumnForParentId);

        DbIndexForName = CreateDbIndexName(DbTable, DbColumnForName);

        DbIndexForParentId = CreateDbIndexName(DbTable, DbColumnForParentId);

        DbIndexForTreeSort = CreateDbIndexName(DbTable, DbColumnForTreeSort);

        DbMaxLengthForName = 256;

        DbMaxLengthForTreePath = 900;

        DbMaxLengthForTreeSort = 900;

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

        DbUniqueIndexForParentIdAndName = CreateDbUniqueIndexName(
            DbTable,
            DbColumnForParentId,
            DbColumnForName);
    }

    #endregion Constructors
}