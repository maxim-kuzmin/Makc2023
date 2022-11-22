// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyMain;

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
    /// Колонка в базе данных для поля идентификатора сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public string? DbColumnForDummyOneToManyEntityId { get; set; }

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
    /// Колонка в базе данных для поля "PropDateTimeOffset".
    /// </summary>
    public string? DbColumnForPropDateTimeOffset { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "PropDateTimeOffsetNullable".
    /// </summary>
    public string? DbColumnForPropDateTimeOffsetNullable { get; set; }

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
    /// Внешний ключ в базе данных к сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public string? DbForeignKeyToDummyOneToManyEntity { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля идентификатора сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public string? DbIndexForDummyOneToManyEntityId { get; set; }

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
    /// <param name="optionsOfDummyOneToManyType">Параметры типа "Фиктивное отношение один ко многим".</param>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public DummyMainTypeOptions(
        DummyOneToManyTypeOptions optionsOfDummyOneToManyType,
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

        if (string.IsNullOrWhiteSpace(optionsOfDummyOneToManyType.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<DummyMainTypeOptions>(
                nameof(optionsOfDummyOneToManyType),
                nameof(optionsOfDummyOneToManyType.DbColumnForId));
        }

        DbColumnForDummyOneToManyEntityId = CreateDbColumnName(
            optionsOfDummyOneToManyType.DbTable,
            optionsOfDummyOneToManyType.DbColumnForId);

        DbForeignKeyToDummyOneToManyEntity = CreateDbForeignKeyName(DbTable, optionsOfDummyOneToManyType.DbTable);

        DbIndexForDummyOneToManyEntityId = CreateDbIndexName(DbTable, DbColumnForDummyOneToManyEntityId);

        DbMaxLengthForName = 256;

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

        DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);
    }

    #endregion Constructors
}
