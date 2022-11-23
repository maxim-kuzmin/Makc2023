// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyTreeLink;

/// <summary>
/// Параметры типа "Связь фиктивного дерева".
/// </summary>
public class DummyTreeLinkTypeOptions : TypeOptions
{
    #region Properties

    /// <summary>
    /// Колонка в базе данных для поля "Id".
    /// </summary>
    public string? DbColumnForId { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля идентификатора родителя сущности "DummyTreeEntity".
    /// </summary>
    public string? DbColumnForDummyTreeEntityParentId { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к сущности "Фиктивное дерево".
    /// </summary>
    public string? DbForeignKeyToDummyTreeEntity { get; set; }

    /// <summary>
    /// Первичный ключ в базе данных.
    /// </summary>
    public string? DbPrimaryKey { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dummyTreeTypeOptions">Параметры типа "Фиктивное дерево".</param>
    /// <param name="defaults">Значения по умолчанию в базе данных.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public DummyTreeLinkTypeOptions(
        DummyTreeTypeOptions dummyTreeTypeOptions,
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        DbColumnForId = defaults.DbColumnForId;

        DbColumnForDummyTreeEntityParentId = defaults.DbColumnForParentId;

        DbForeignKeyToDummyTreeEntity = CreateDbForeignKeyName(DbTable, dummyTreeTypeOptions.DbTable);

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
    }

    #endregion Constructors
}
