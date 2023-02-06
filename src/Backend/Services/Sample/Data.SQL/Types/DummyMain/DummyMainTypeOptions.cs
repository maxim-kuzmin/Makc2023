﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyMain;

/// <summary>
/// Параметры типа "Фиктивное главное".
/// </summary>
public class DummyMainTypeOptions : TypeOptions
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
    /// Колонка в базе данных для поля "DummyOneToManyId".
    /// </summary>
    public string? DbColumnForDummyOneToManyId { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropBoolean".
    /// </summary>
    public string? DbColumnForPropBoolean { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropBooleanNullable".
    /// </summary>
    public string? DbColumnForPropBooleanNullable { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropDate".
    /// </summary>
    public string? DbColumnForPropDate { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropDateNullable".
    /// </summary>
    public string? DbColumnForPropDateNullable { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropDateTime".
    /// </summary>
    public string? DbColumnForPropDateTime { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropDateTimeNullable".
    /// </summary>
    public string? DbColumnForPropDateTimeNullable { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropDecimal".
    /// </summary>
    public string? DbColumnForPropDecimal { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropDecimalNullable".
    /// </summary>
    public string? DbColumnForPropDecimalNullable { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropInt32".
    /// </summary>
    public string? DbColumnForPropInt32 { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropInt32Nullable".
    /// </summary>
    public string? DbColumnForPropInt32Nullable { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropInt64".
    /// </summary>
    public string? DbColumnForPropInt64 { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropInt64Nullable".
    /// </summary>
    public string? DbColumnForPropInt64Nullable { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropString".
    /// </summary>
    public string? DbColumnForPropString { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropStringNullable".
    /// </summary>
    public string? DbColumnForPropStringNullable { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к типу "Фиктивное отношение один ко многим".
    /// </summary>
    public string? DbForeignKeyToDummyOneToMany { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля "DummyOneToManyId".
    /// </summary>
    public string? DbIndexForDummyOneToManyId { get; set; }

    /// <summary>
    /// Максимальная длина в базе данных для поля "Name".
    /// </summary>
    public int DbMaxLengthForName { get; set; }

    /// <summary>
    /// Первичный ключ в базе данных.
    /// </summary>
    public string? DbPrimaryKey { get; set; }

    /// <summary>
    /// Уникальный индекс в базе данных для поля "Name".
    /// </summary>
    public string? DbUniqueIndexForName { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dummyOneToManyTypeOptions">Параметры типа "Фиктивное отношение один ко многим".</param>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public DummyMainTypeOptions(
        DummyOneToManyTypeOptions dummyOneToManyTypeOptions,
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        DbColumnForId = defaults.DbColumnForId;

        if (string.IsNullOrWhiteSpace(defaults.DbColumnForName))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyMainTypeOptions>(
                nameof(defaults),
                nameof(defaults.DbColumnForName));
        }

        DbColumnForName = defaults.DbColumnForName;

        if (string.IsNullOrWhiteSpace(dummyOneToManyTypeOptions.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyMainTypeOptions>(
                nameof(dummyOneToManyTypeOptions),
                nameof(dummyOneToManyTypeOptions.DbColumnForId));
        }

        DbColumnForDummyOneToManyId = CreateDbColumnName(
            dummyOneToManyTypeOptions.DbTable,
            dummyOneToManyTypeOptions.DbColumnForId);

        DbForeignKeyToDummyOneToMany = CreateDbForeignKeyName(DbTable, dummyOneToManyTypeOptions.DbTable);

        DbIndexForDummyOneToManyId = CreateDbIndexName(DbTable, DbColumnForDummyOneToManyId);

        DbMaxLengthForName = 256;

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

        DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);
    }

    #endregion Constructors
}
