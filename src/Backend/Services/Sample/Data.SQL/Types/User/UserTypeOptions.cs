// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.User;

/// <summary>
/// Параметры типа "Пользователь".
/// </summary>
public class UserTypeOptions : TypeOptions
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
    /// Колонка в базе данных для поля "Email".
    /// </summary>
    public string? DbColumnForEmail { get; set; }

    /// <summary>
    /// Колонка в базе данных для поля "IsBlocked".
    /// </summary>
    public string? DbColumnForIsBlocked { get; set; }

    /// <summary>
    /// Максимальная длина в базе данных для поля "Name".
    /// </summary>
    public int DbMaxLengthForName { get; set; }

    /// <summary>
    /// Максимальная длина в базе данных для поля "Email".
    /// </summary>
    public int DbMaxLengthForEmail { get; set; }

    /// <summary>
    /// Первичный ключ в базе данных.
    /// </summary>
    public string? DbPrimaryKey { get; set; }

    /// <summary>
    /// Уникальный индекс в базе данных для поля "Name".
    /// </summary>
    public string? DbUniqueIndexForName { get; set; }

    /// <summary>
    /// Уникальный индекс в базе данных для поля "Email".
    /// </summary>
    public string? DbUniqueIndexForEmail { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    /// <param name="dbColumnNameForEmail">Колонка в базе данных для поля "Email".</param>
    public UserTypeOptions(
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null,
        string? dbColumnNameForEmail = null)
        : base(defaults, dbTable, dbSchema)
    {
        DbColumnForId = defaults.DbColumnForId;

        if (string.IsNullOrWhiteSpace(defaults.DbColumnForName))
        {
            throw new NullOrWhiteSpaceStringVariableException<UserTypeOptions>(
                nameof(defaults),
                nameof(defaults.DbColumnForName));
        }

        DbColumnForName = defaults.DbColumnForName;

        DbColumnForEmail = dbColumnNameForEmail ?? nameof(UserTypeEntity.Email);

        DbMaxLengthForName = 256;

        DbMaxLengthForEmail = 256;

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

        DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);

        DbUniqueIndexForEmail = CreateDbUniqueIndexName(DbTable, DbColumnForEmail);
    }

    #endregion Constructors
}
