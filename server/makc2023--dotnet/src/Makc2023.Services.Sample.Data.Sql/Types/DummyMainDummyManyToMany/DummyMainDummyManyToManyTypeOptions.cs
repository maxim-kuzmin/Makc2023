// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyMainDummyManyToMany;

/// <summary>
/// Параметры типа "Фиктивное отношение многие ко многим фиктивного главного".
/// </summary>
public class DummyMainDummyManyToManyTypeOptions : TypeOptions
{
    #region Properties

    /// <summary>
    /// Колонка в базе данных для поля идентификатора сущности "Фиктивное главное".
    /// </summary>
    public string? DbColumnForDummyMainEntityId { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля идентификатора сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public string? DbColumnForDummyManyToManyEntityId { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к сущности "Фиктивное главное".
    /// </summary>
    public string? DbForeignKeyToDummyMainEntity { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public string? DbForeignKeyToDummyManyToManyEntity { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля идентификатора сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public string? DbIndexForDummyManyToManyEntityId { get; set; }

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

        DbColumnForDummyMainEntityId = CreateDbColumnName(
            dummyMainTypeOptions.DbTable,
            dummyMainTypeOptions.DbColumnForId);

        if (string.IsNullOrWhiteSpace(dummyManyToManyTypeOptions.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyMainDummyManyToManyTypeOptions>(
                nameof(dummyManyToManyTypeOptions),
                nameof(dummyManyToManyTypeOptions.DbColumnForId));
        }

        DbColumnForDummyManyToManyEntityId = CreateDbColumnName(
            dummyManyToManyTypeOptions.DbTable,
            dummyManyToManyTypeOptions.DbColumnForId);


        DbForeignKeyToDummyMainEntity = CreateDbForeignKeyName(DbTable, dummyMainTypeOptions.DbTable);

        DbForeignKeyToDummyManyToManyEntity = CreateDbForeignKeyName(DbTable, dummyManyToManyTypeOptions.DbTable);

        DbIndexForDummyManyToManyEntityId = CreateDbIndexName(DbTable, DbColumnForDummyManyToManyEntityId);

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
    }

    #endregion Constructors
}
