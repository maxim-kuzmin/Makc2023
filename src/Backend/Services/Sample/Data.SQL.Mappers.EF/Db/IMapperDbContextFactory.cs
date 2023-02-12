﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Db;

/// <summary>
/// Фабрика контекста базы данных сопоставителя.
/// </summary>
/// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
public interface IMapperDbContextFactory<TDbContext>
{
    #region Methods

    /// <summary>
    /// Создать контекст базы данных.
    /// </summary>
    /// <returns>Контекст базы данных.</returns>
    TDbContext CreateDbContext();

    #endregion Methods
}
