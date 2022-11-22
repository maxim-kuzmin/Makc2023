// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Sql.Types.InternalPermission;

/// <summary>
/// Параметры типа "Внутреннее разрешение".
/// </summary>
public class InternalPermissionTypeOptions : TypeOptions
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
    /// Колонка в базе данных для поля идентификатора сущности "Внутренний домен".
    /// </summary>
    public string? DbColumnForInternalDomainEntityId { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к сущности "Внутренний домен".
    /// </summary>
    public string? DbForeignKeyToInternalDomainEntity { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля идентификатора сущности "Внутренний домен".
    /// </summary>
    public string? DbIndexForInternalDomainEntityId { get; set; }

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
    /// <param name="optionsOfInternalDomainType">Параметры типа "Внутренний домен".</param>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public InternalPermissionTypeOptions(
        InternalDomainTypeOptions optionsOfInternalDomainType,
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        DbColumnForId = defaults.DbColumnForId;

        if (string.IsNullOrWhiteSpace(defaults.DbColumnForName))
        {
            throw new NullOrWhiteSpaceStringVariableException<InternalPermissionTypeOptions>(
                nameof(defaults),
                nameof(defaults.DbColumnForName));
        }

        DbColumnForName = defaults.DbColumnForName;

        if (string.IsNullOrWhiteSpace(optionsOfInternalDomainType.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<InternalPermissionTypeOptions>(
                nameof(optionsOfInternalDomainType),
                nameof(optionsOfInternalDomainType.DbColumnForId));
        }

        DbColumnForInternalDomainEntityId = CreateDbColumnName(
            optionsOfInternalDomainType.DbTable,
            optionsOfInternalDomainType.DbColumnForId);

        DbForeignKeyToInternalDomainEntity = CreateDbForeignKeyName(DbTable, optionsOfInternalDomainType.DbTable);

        DbIndexForInternalDomainEntityId = CreateDbIndexName(DbTable, DbColumnForInternalDomainEntityId);

        DbMaxLengthForName = 256;

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

        DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);
    }

    #endregion Constructors
}
