// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Db;

public class MapperDbManager : MapperDbManager<MapperDbContext>
{
    #region Properties

    /// <summary>
    /// Фабрика контекста базы данных.
    /// </summary>
    public IMapperDbContextFactory DbContextFactory { get; init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Контсруктор.
    /// </summary>
    /// <param name="dbContextFactory">Фабрика контекста базы данных.</param>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="resource">Ресурс.</param>
    public MapperDbManager(
        IMapperDbContextFactory dbContextFactory,
        MapperDbContext dbContext,
        IMapperResource resource)
        : base(dbContext, resource)
    {
        DbContextFactory = dbContextFactory;
    }

    #endregion Constructors
}
