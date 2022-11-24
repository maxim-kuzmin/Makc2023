﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Db;

/// <summary>
/// Фабрика контекста базы данных сопоставителя.
/// </summary>
public interface IMapperDbContextFactory
{
    #region Methods

    /// <summary>
    /// Создать контекст базы данных.
    /// </summary>
    /// <returns>Контекст базы данных.</returns>
    MapperDbContext CreateDbContext();

    #endregion Methods
}
