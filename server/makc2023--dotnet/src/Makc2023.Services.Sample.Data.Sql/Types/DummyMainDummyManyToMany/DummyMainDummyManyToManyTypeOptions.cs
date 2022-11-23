// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyMainDummyManyToMany;

/// <summary>
/// Параметры типа "Фиктивное отношение многие ко многим фиктивного главного".
/// </summary>
public class DummyMainDummyManyToManyTypeOptions : TypeOptions
{
    #region Properties

    /// <summary>
    /// Колонка в базе данных для поля "DummyMainId".
    /// </summary>
    public string? DbColumnForDummyMainId { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "DummyManyToManyId".
    /// </summary>
    public string? DbColumnForDummyManyToManyId { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к типу "Фиктивное главное".
    /// </summary>
    public string? DbForeignKeyToDummyMain { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к типу "Фиктивное отношение многие ко многим".
    /// </summary>
    public string? DbForeignKeyToDummyManyToMany { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля "DummyManyToManyId".
    /// </summary>
    public string? DbIndexForDummyManyToManyId { get; set; }

    /// <summary>
    /// Первичный ключ в базе данных.
    /// </summary>
    public string? DbPrimaryKey { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dummyMainTypeOptions">Параметры типа "Фиктивное главное".</param>
    /// <param name="dummyManyToManyTypeOptions">Параметры типа "Фиктивное отношение многие ко многим".</param>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public DummyMainDummyManyToManyTypeOptions(
        DummyMainTypeOptions dummyMainTypeOptions,
        DummyManyToManyTypeOptions dummyManyToManyTypeOptions,
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        if (string.IsNullOrWhiteSpace(dummyMainTypeOptions.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyMainDummyManyToManyTypeOptions>(
                nameof(dummyMainTypeOptions),
                nameof(dummyMainTypeOptions.DbColumnForId));
        }

        DbColumnForDummyMainId = CreateDbColumnName(
            dummyMainTypeOptions.DbTable,
            dummyMainTypeOptions.DbColumnForId);

        if (string.IsNullOrWhiteSpace(dummyManyToManyTypeOptions.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyMainDummyManyToManyTypeOptions>(
                nameof(dummyManyToManyTypeOptions),
                nameof(dummyManyToManyTypeOptions.DbColumnForId));
        }

        DbColumnForDummyManyToManyId = CreateDbColumnName(
            dummyManyToManyTypeOptions.DbTable,
            dummyManyToManyTypeOptions.DbColumnForId);


        DbForeignKeyToDummyMain = CreateDbForeignKeyName(DbTable, dummyMainTypeOptions.DbTable);

        DbForeignKeyToDummyManyToMany = CreateDbForeignKeyName(DbTable, dummyManyToManyTypeOptions.DbTable);

        DbIndexForDummyManyToManyId = CreateDbIndexName(DbTable, DbColumnForDummyManyToManyId);

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
    }

    #endregion Constructors
}
