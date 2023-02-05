﻿// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Setup;

/// <summary>
/// Интерфейс сервиса настройки.
/// </summary>
public interface ISetupService
{
    #region Methods

    /// <summary>
    /// Мигрировать базу данных.
    /// </summary>
    Task MigrateDatabase();

    /// <summary>
    /// Засеять тестовые данные.
    /// </summary>
    Task SeedTestData();

    #endregion Methods
}
