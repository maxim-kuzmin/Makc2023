// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2023.Backend.Common.Domain;

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain;

/// <summary>
/// Репозиторий домена.
/// </summary>
public class DomainRepository : MapperRepository<DummyMainEntity>, IDummyMainRepository
{
    #region Fields

    private readonly IMapperDbContextFactory _dbContextFactory;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContextFactory">Фабрика контекста базы данных.</param>
    /// <param name="mediator">Посредник.</param>
    public DomainRepository(
        IMapperDbContextFactory dbContextFactory,
        MapperDbManager dbManager,
        IMediator mediator)
        : base(dbManager.DbContext, mediator)
    {
        _dbContextFactory = dbContextFactory;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<DummyMainItemGetOperationOutput> GetItem(DummyMainItemGetOperationInput input)
    {
        DummyMainItemGetOperationOutput result = new();

        using var dbContext = _dbContextFactory.CreateDbContext();

        var taskForItem = dbContext.DummyMain
            .Include(x => x.DummyOneToMany)
            .Include(x => x.DummyMainDummyManyToManyList)
            .Include(x => x.DummyManyToOneList)
            .ApplyFiltering(input)
            .SingleOrDefaultAsync();

        var mapperDummyMain = await taskForItem.ConfigureAwait(false);

        if (mapperDummyMain != null)
        {
            var item = new DummyMainEntity(mapperDummyMain);

            LoadDummyOneToMany(item, mapperDummyMain);

            LoadDummyManyToOne(item, mapperDummyMain);

            await LoadDummyManyToMany(dbContext, item, mapperDummyMain).ConfigureAwait(false);            

            result.Item = item;
        }
        else
        {
            result.IsItemNotFound = true;
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<DummyMainListGetOperationOutput> GetList(DummyMainListGetOperationInput input)
    {
        DummyMainListGetOperationOutput result = new();

        using var dbContext = _dbContextFactory.CreateDbContext();
        using var dbContextForTotalCount = _dbContextFactory.CreateDbContext();

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

        var mapperDummyMainList = await taskForItems.ConfigureAwait(false);

        var itemLookup = mapperDummyMainList
            .Select(x => new DummyMainEntity(x))
            .ToDictionary(x => x.Data.Id);

        if (mapperDummyMainList.Any())
        {
            LoadDummyOneToMany(itemLookup, mapperDummyMainList);

            LoadDummyManyToOne(itemLookup, mapperDummyMainList);

            await LoadDummyManyToMany(dbContext, itemLookup, mapperDummyMainList).ConfigureAwait(false);
        }

        result.Items = itemLookup.Values.ToArray();
        result.TotalCount = await taskForTotalCount.ConfigureAwait(false);

        return result;
    }

    #endregion Public methods

    #region Private methods

    private static async Task LoadDummyManyToMany(
        MapperDbContext dbContext,
        DummyMainEntity item,
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
                var taskForList = dbContext.DummyManyToMany
                    .Where(x => mapperDummyManyToManyIds.Contains(x.Id))
                    .ToArrayAsync();

                var mapperDummyManyToManyList = await taskForList.ConfigureAwait(false);

                foreach (var mapperDummyManyToMany in mapperDummyManyToManyList)
                {
                    item.AddDummyManyToMany(mapperDummyManyToMany);
                }
            }
        }
    }

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
            var taskForLookup = dbContext.DummyManyToMany
                .Where(x => mapperDummyManyToManyIdsForLookup.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id);

            var mapperDummyManyToManyLookup = await taskForLookup.ConfigureAwait(false);

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

    private static void LoadDummyManyToOne(DummyMainEntity item, MapperDummyMainTypeEntity mapperDummyMain)
    {
        var mapperDummyManyToOneList = mapperDummyMain.DummyManyToOneList;

        if (mapperDummyManyToOneList.Any())
        {
            foreach (var mapperDummyManyToOne in mapperDummyManyToOneList)
            {
                item.AddDummyManyToOne(mapperDummyManyToOne);
            }
        }
    }

    private static void LoadDummyManyToOne(
        Dictionary<long, DummyMainEntity> itemLookup,
        MapperDummyMainTypeEntity[] mapperDummyMainList)
    {
        foreach (var mapperDummyMain in mapperDummyMainList)
        {
            if (itemLookup.TryGetValue(mapperDummyMain.Id, out DummyMainEntity? item))
            {
                LoadDummyManyToOne(item, mapperDummyMain);
            }
        }
    }

    private static void LoadDummyOneToMany(DummyMainEntity item, MapperDummyMainTypeEntity mapperDummyMain)
    {
        var mapperDummyOneToMany = mapperDummyMain.DummyOneToMany;

        if (mapperDummyOneToMany != null)
        {
            item.DummyOneToMany = new DummyOneToManyEntity(mapperDummyOneToMany);
        }
    }

    private static void LoadDummyOneToMany(
        Dictionary<long, DummyMainEntity> itemLookup,
        MapperDummyMainTypeEntity[] mapperDummyMainList)
    {
        foreach (var mapperDummyMain in mapperDummyMainList)
        {
            if (itemLookup.TryGetValue( mapperDummyMain.Id, out DummyMainEntity? item))
            {
                LoadDummyOneToMany(item, mapperDummyMain);
            }
        }
    }

    #endregion Private methods
}
