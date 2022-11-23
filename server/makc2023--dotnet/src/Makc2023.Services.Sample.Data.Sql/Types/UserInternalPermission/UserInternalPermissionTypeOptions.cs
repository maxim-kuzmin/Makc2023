// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.UserInternalPermission;

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
    /// <param name="userTypeOptions">Параметры типа "Пользователь".</param>
    /// <param name="internalPermissionTypeOptions">Параметры типа "Внутреннее разрешение".</param>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public UserInternalPermissionTypeOptions(
        UserTypeOptions userTypeOptions,
        InternalPermissionTypeOptions internalPermissionTypeOptions,
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        if (string.IsNullOrWhiteSpace(userTypeOptions.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<UserInternalPermissionTypeOptions>(
                nameof(userTypeOptions),
                nameof(userTypeOptions.DbColumnForId));
        }

        DbColumnForUserEntityId = CreateDbColumnName(
            userTypeOptions.DbTable,
            userTypeOptions.DbColumnForId);

        if (string.IsNullOrWhiteSpace(internalPermissionTypeOptions.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<UserInternalPermissionTypeOptions>(
                nameof(internalPermissionTypeOptions),
                nameof(internalPermissionTypeOptions.DbColumnForId));
        }

        DbColumnForInternalPermissionEntityId = CreateDbColumnName(
            internalPermissionTypeOptions.DbTable,
            internalPermissionTypeOptions.DbColumnForId);


        DbForeignKeyToUserEntity = CreateDbForeignKeyName(DbTable, userTypeOptions.DbTable);

        DbForeignKeyToInternalPermissionEntity = CreateDbForeignKeyName(DbTable, internalPermissionTypeOptions.DbTable);

        DbIndexForInternalPermissionEntityId = CreateDbIndexName(DbTable, DbColumnForInternalPermissionEntityId);

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
    }

    #endregion Constructors
}
