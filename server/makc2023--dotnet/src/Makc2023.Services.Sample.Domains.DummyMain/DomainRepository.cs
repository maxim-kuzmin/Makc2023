// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain;

/// <summary>
/// Репозиторий домена.
/// </summary>
public class DomainRepository : MapperRepository<DummyMainEntity>, IDummyMainRepository
{
    #region Properties

    private MapperDbManager DbManager { get; init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbManager">Менеджер базы данных.</param>
    /// <param name="mediator">Посредник.</param>
    public DomainRepository(MapperDbManager dbManager, IMediator mediator)
        : base(dbManager.DbContext, mediator)
    {
        DbManager = dbManager;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<DummyMainItemGetOperationOutput> GetItem(DummyMainItemGetOperationInput input)
    {
        DummyMainItemGetOperationOutput result = new();

        using var dbContext = DbManager.DbContextFactory.CreateDbContext();

        var mapperDummyMain = await dbContext.DummyMain
            .Include(x => x.DummyOneToMany)
            .Include(x => x.DummyMainDummyManyToManyList)
            .Include(x => x.DummyManyToOneList)
            .ApplyFiltering(input)
            .SingleOrDefaultAsync();

        if (mapperDummyMain != null)
        {
            var entity = new DummyMainEntity(mapperDummyMain);

            await LoadDummyManyToMany(dbContext, entity, mapperDummyMain);

            LoadDummyManyToOne(entity, mapperDummyMain);

            LoadDummyOneToMany(entity, mapperDummyMain);

            result.Entity = entity;
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<DummyMainListGetOperationOutput> GetList(DummyMainListGetOperationInput input)
    {
        DummyMainListGetOperationOutput result = new();

        using var dbContext = DbManager.DbContextFactory.CreateDbContext();
        using var dbContextForTotalCount = DbManager.DbContextFactory.CreateDbContext();

        var queryForItems = dbContext.DummyMain
            .Include(x => x.DummyOneToMany)
            .Include(x => x.DummyMainDummyManyToManyList)
            .Include(x => x.DummyManyToOneList)
            .ApplyFiltering(input)
            .ApplySorting(input)
            .ApplyPagination(input);

        var queryForTotalCount = dbContextForTotalCount.DummyMain
            .ApplyFiltering(input);

        var taskForItems = queryForItems.ToArrayAsync();
        var taskForTotalCount = queryForTotalCount.CountAsync();

        await Task.WhenAll(taskForItems, taskForTotalCount);

        var mapperDummyMainList = taskForItems.Result;

        var itemLookup = mapperDummyMainList
            .Select(x => new DummyMainEntity(x))
            .ToDictionary(x => x.Data.Id);

        result.Items = itemLookup.Values.ToArray();
        result.TotalCount = taskForTotalCount.Result;

        if (mapperDummyMainList.Any())
        {
            await LoadDummyManyToMany(dbContext, itemLookup, mapperDummyMainList);

            LoadDummyManyToOne(itemLookup, mapperDummyMainList);
        }

        return result;
    }

    #endregion Public methods

    #region Private methods

    private static async Task LoadDummyManyToMany(
        MapperDbContext dbContext,
        Dictionary<long, DummyMainEntity> itemLookup,
        MapperDummyMainTypeEntity[] mapperDummyMainList)
    {
        long[] mapperDummyManyToManyIdsForLookup = mapperDummyMainList
            .SelectMany(x => x.DummyMainDummyManyToManyList)
            .Select(x => x.DummyManyToManyId)
            .Distinct()
            .ToArray();

        if (mapperDummyManyToManyIdsForLookup.Any())
        {
            var mapperDummyManyToManyLookup = await dbContext.DummyManyToMany
                .Where(x => mapperDummyManyToManyIdsForLookup.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id);

            if (mapperDummyManyToManyLookup.Any())
            {
                foreach (var mapperDummyMain in mapperDummyMainList)
                {
                    if (itemLookup.TryGetValue(
                        mapperDummyMain.Id,
                        out DummyMainEntity? item))
                    {
                        long[] mapperDummyManyToManyIds = mapperDummyMain.DummyMainDummyManyToManyList
                            .Select(x => x.DummyManyToManyId)
                            .ToArray();

                        foreach (long mapperDummyManyToManyId in mapperDummyManyToManyIds)
                        {
                            if (mapperDummyManyToManyLookup.TryGetValue(
                                mapperDummyManyToManyId,
                                out MapperDummyManyToManyTypeEntity? mapperDummyManyToMany))
                            {
                                item.AddDummyManyToMany(mapperDummyManyToMany);
                            }
                        }
                    }
                }
            }
        }
    }

    private static void LoadDummyManyToOne(
        Dictionary<long, DummyMainEntity> itemLookup,
        MapperDummyMainTypeEntity[] mapperDummyMainList)
    {
        foreach (var mapperDummyMain in mapperDummyMainList)
        {
            if (itemLookup.TryGetValue(
                mapperDummyMain.Id,
                out DummyMainEntity? item))
            {
                foreach (var mapperDummyManyToOne in mapperDummyMain.DummyManyToOneList)
                {
                    item.AddDummyManyToOne(mapperDummyManyToOne);
                }
            }
        }
    }

    private static async Task LoadDummyManyToMany(
        MapperDbContext dbContext,
        DummyMainEntity entity,
        MapperDummyMainTypeEntity mapperDummyMain)
    {
        var mapperDummyMainDummyManyToManyList = mapperDummyMain.DummyMainDummyManyToManyList;

        if (mapperDummyMainDummyManyToManyList.Any())
        {
            long[] mapperDummyManyToManyIds = mapperDummyMainDummyManyToManyList
                .Select(x => x.DummyManyToManyId)
                .ToArray();

            if (mapperDummyManyToManyIds.Any())
            {
                var mapperDummyManyToManyList = await dbContext.DummyManyToMany
                    .Where(x => mapperDummyManyToManyIds.Contains(x.Id))
                    .ToArrayAsync();

                foreach (var mapperDummyManyToMany in mapperDummyManyToManyList)
                {
                    entity.AddDummyManyToMany(mapperDummyManyToMany);
                }
            }
        }
    }

    private static void LoadDummyManyToOne(
        DummyMainEntity entity,
        MapperDummyMainTypeEntity mapperDummyMain)
    {
        var mapperDummyManyToOneList = mapperDummyMain.DummyManyToOneList;

        if (mapperDummyManyToOneList.Any())
        {
            foreach (var mapperDummyManyToOne in mapperDummyManyToOneList)
            {
                entity.AddDummyManyToOne(mapperDummyManyToOne);
            }
        }
    }

    private static void LoadDummyOneToMany(
        DummyMainEntity entity,
        MapperDummyMainTypeEntity mapperDummyMain)
    {
        var mapperDummyOneToMany = mapperDummyMain.DummyOneToMany;

        if (mapperDummyOneToMany != null)
        {
            entity.DummyOneToMany = new DummyOneToManyEntity(mapperDummyOneToMany);
        }
    }

    #endregion Private methods
}
