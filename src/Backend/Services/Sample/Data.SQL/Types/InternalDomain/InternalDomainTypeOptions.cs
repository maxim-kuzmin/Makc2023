﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.InternalDomain;

/// <summary>
/// Параметры типа "Внутренний домен".
/// </summary>
public class InternalDomainTypeOptions : TypeOptions
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
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="dbTable">Таблица в базе данных.</param>
    /// <param name="dbSchema">Схема в базе данных.</param>
    public InternalDomainTypeOptions(
        IDefaults defaults,
        string dbTable,
        string? dbSchema = null
        )
        : base(defaults, dbTable, dbSchema)
    {
        DbColumnForId = defaults.DbColumnForId;

        if (string.IsNullOrWhiteSpace(defaults.DbColumnForName))
        {
            throw new NullOrWhiteSpaceStringVariableException<InternalDomainTypeOptions>(
                nameof(defaults),
                nameof(defaults.DbColumnForName));
        }

        DbColumnForName = defaults.DbColumnForName;

        DbMaxLengthForName = 256;

        DbPrimaryKey = CreateDbPrimaryKeyName(DbTable);

        DbUniqueIndexForName = CreateDbUniqueIndexName(DbTable, DbColumnForName);
    }

    #endregion Constructors
}
