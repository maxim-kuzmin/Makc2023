// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Types.UserInternalPermission;

/// <summary>
/// Параметры типа "Внутреннее разрешение пользователя".
/// </summary>
public class UserInternalPermissionTypeOptions : TypeOptions
{
    #region Properties

    /// <summary>
    /// Колонка в базе данных для поля "UserId".
    /// </summary>
    public string? DbColumnForUserId { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "InternalPermissionId".
    /// </summary>
    public string? DbColumnForInternalPermissionId { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к типу "Пользователь".
    /// </summary>
    public string? DbForeignKeyToUser { get; set; }

    /// <summary>
    /// Внешний ключ в базе данных к типу "Внутреннее разрешение".
    /// </summary>
    public string? DbForeignKeyToInternalPermission { get; set; }

    /// <summary>
    /// Индекс в базе данных для поля "InternalPermissionId".
    /// </summary>
    public string? DbIndexForInternalPermissionId { get; set; }

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

        DbColumnForUserId = CreateDbColumnName(
            userTypeOptions.DbTable,
            userTypeOptions.DbColumnForId);

        if (string.IsNullOrWhiteSpace(internalPermissionTypeOptions.DbColumnForId))
        {
            throw new NullOrWhiteSpaceStringVariableException<UserInternalPermissionTypeOptions>(
                nameof(internalPermissionTypeOptions),
                nameof(internalPermissionTypeOptions.DbColumnForId));
        }

        DbColumnForInternalPermissionId = CreateDbColumnName(
            internalPermissionTypeOptions.DbTable,
            internalPermissionTypeOptions.DbColumnForId);


        DbForeignKeyToUser = CreateDbForeignKeyName(DbTable, userTypeOptions.DbTable);

        DbForeignKeyToInternalPermission = CreateDbForeignKeyName(DbTable, internalPermissionTypeOptions.DbTable);

        DbIndexForInternalPermissionId = CreateDbIndexName(DbTable, DbColumnForInternalPermissionId);

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);
    }

    #endregion Constructors
}
