// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF;

/// <summary>
/// Интерфейс сервиса сопоставителя.
/// </summary>
public interface IMapperService
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
