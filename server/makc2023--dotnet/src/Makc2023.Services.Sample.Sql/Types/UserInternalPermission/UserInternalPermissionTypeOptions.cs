// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Sql.Types.UserInternalPermission;

/// <summary>
/// Параметры типа "Внутреннее разрешение пользователя".
/// </summary>
public class UserInternalPermissionTypeOptions : TypeOptions
{
    #region Properties

    /// <summary>
    /// Колонка в базе данных для поля идентификатора сущности "Пользователь".
    /// </summary>
    public string? DbColumnForUserEntityId { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля идентификатора сущности "Внутреннее разрешение".
    /// </summary>
    public string? DbColumnForInternalPermissionEntityId { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к сущности "Пользователь".
    /// </summary>
    public string? DbForeignKeyToUserEntity { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к сущности "Внутреннее разрешение".
    /// </summary>
    public string? DbForeignKeyToInternalPermissionEntity { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля идентификатора сущности "Внутреннее разрешение".
    /// </summary>
    public string? DbIndexForInternalPermissionEntityId { get; set; }

    /// <summary>
    /// Первичный ключ в базе данных.
    /// </summary>
    public string? DbPrimaryKey { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="optionsOfUserType">Параметры типа "Пользователь".</param>
    /// <param name="optionsOfInternalPermissionType">Параметры типа "Внутреннее разрешение".</param>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public UserInternalPermissionTypeOptions(
        UserTypeOptions optionsOfUserType,
        InternalPermissionTypeOptions optionsOfInternalPermissionType,
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        if (string.IsNullOrWhiteSpace(optionsOfUserType.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<UserInternalPermissionTypeOptions>(
                nameof(optionsOfUserType),
                nameof(optionsOfUserType.DbColumnForId));
        }

        DbColumnForUserEntityId = CreateDbColumnName(
            optionsOfUserType.DbTable,
            optionsOfUserType.DbColumnForId);

        if (string.IsNullOrWhiteSpace(optionsOfInternalPermissionType.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<UserInternalPermissionTypeOptions>(
                nameof(optionsOfInternalPermissionType),
                nameof(optionsOfInternalPermissionType.DbColumnForId));
        }

        DbColumnForInternalPermissionEntityId = CreateDbColumnName(
            optionsOfInternalPermissionType.DbTable,
            optionsOfInternalPermissionType.DbColumnForId);


        DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, optionsOfUserType.DbTable);

        DbForeignKeyToInternalPermissionEntity = CreateDbForeignKeyName(DbTable, optionsOfInternalPermissionType.DbTable);

        DbIndexForInternalPermissionEntityId = CreateDbIndexName(DbTable, DbColumnForInternalPermissionEntityId);

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
    }

    #endregion Constructors
}
