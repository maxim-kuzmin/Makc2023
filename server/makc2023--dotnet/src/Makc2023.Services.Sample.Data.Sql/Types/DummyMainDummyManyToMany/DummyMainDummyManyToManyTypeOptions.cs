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
    /// <param name="optionsOfDummyMainType">Параметры типа "Фиктивное главное".</param>
    /// <param name="optionsOfDummyManyToManyType">Параметры типа "Фиктивное отношение многие ко многим".</param>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public DummyMainDummyManyToManyTypeOptions(
        DummyMainTypeOptions optionsOfDummyMainType,
        DummyManyToManyTypeOptions optionsOfDummyManyToManyType,
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        if (string.IsNullOrWhiteSpace(optionsOfDummyMainType.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyMainDummyManyToManyTypeOptions>(
                nameof(optionsOfDummyMainType),
                nameof(optionsOfDummyMainType.DbColumnForId));
        }

        DbColumnForDummyMainEntityId = CreateDbColumnName(
            optionsOfDummyMainType.DbTable,
            optionsOfDummyMainType.DbColumnForId);

        if (string.IsNullOrWhiteSpace(optionsOfDummyManyToManyType.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyMainDummyManyToManyTypeOptions>(
                nameof(optionsOfDummyManyToManyType),
                nameof(optionsOfDummyManyToManyType.DbColumnForId));
        }

        DbColumnForDummyManyToManyEntityId = CreateDbColumnName(
            optionsOfDummyManyToManyType.DbTable,
            optionsOfDummyManyToManyType.DbColumnForId);


        DbForeignKeyToDummyMainEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyMainType.DbTable);

        DbForeignKeyToDummyManyToManyEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyManyToManyType.DbTable);

        DbIndexForDummyManyToManyEntityId = CreateDbIndexName(DbTable, DbColumnForDummyManyToManyEntityId);

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
    }

    #endregion Constructors
}
