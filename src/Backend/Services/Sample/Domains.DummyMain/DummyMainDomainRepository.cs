// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain;

/// <summary>
/// Репозиторий домена "Фиктивное главное".
/// </summary>
public class DummyMainDomainRepository : MapperRepository<DummyMainDomainEntity>, IDummyMainDomainRepository
{
    #region Fields

    private readonly IClientMapperDbContextFactory _dbContextFactory;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContextFactory">Фабрика контекста базы данных.</param>
    /// <param name="dbManager">Менеджер базы данных.</param>
    /// <param name="mediator">Посредник.</param>
    public DummyMainDomainRepository(
        IClientMapperDbContextFactory dbContextFactory,
        ClientMapperDbManager dbManager,
        IMediator mediator)
        : base(dbManager.DbContext, mediator)
    {
        _dbContextFactory = dbContextFactory;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<DummyMainDomainItemGetOperationOutput> GetItem(DummyMainDomainItemGetOperationInput input)
    {
        DummyMainDomainItemGetOperationOutput result = new();

        using var dbContext = _dbContextFactory.CreateDbContext();

        var taskForItem = dbContext.DummyMain
            .Include(x => x.DummyOneToMany)
            .Include(x => x.DummyMainDummyManyToManyList)
            .Include(x => x.DummyManyToOneList)
            .ApplyFiltering(input)
            .SingleOrDefaultAsync();

        var mapperForItem = await taskForItem.ConfigureAwait(false);

        if (mapperForItem != null)
        {
            var item = new DummyMainDomainEntity(mapperForItem);

            LoadDummyOneToMany(item, mapperForItem);

            LoadDummyManyToOne(item, mapperForItem);

            await LoadDummyManyToMany(dbContext, item, mapperForItem).ConfigureAwait(false);            

            result.Item = item;
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<DummyMainDomainListGetOperationOutput> GetList(DummyMainDomainListGetOperationInput input)
    {
        DummyMainDomainListGetOperationOutput result = new();

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

        var mapperForItems = await taskForItems.ConfigureAwait(false);

        var itemLookup = mapperForItems
            .Select(x => new DummyMainDomainEntity(x))
            .ToDictionary(x => x.Data.Id);

        if (mapperForItems.Any())
        {
            LoadDummyOneToMany(itemLookup, mapperForItems);

            LoadDummyManyToOne(itemLookup, mapperForItems);

            await LoadDummyManyToMany(dbContext, itemLookup, mapperForItems).ConfigureAwait(false);
        }

        result.Items = itemLookup.Values.ToArray();
        result.TotalCount = await taskForTotalCount.ConfigureAwait(false);

        return result;
    }

    #endregion Public methods

    #region Private methods

    private static async Task LoadDummyManyToMany(
        ClientMapperDbContext dbContext,
        DummyMainDomainEntity item,
        ClientMapperDummyMainTypeEntity mapperForItem)
    {
        var mapperDummyMainDummyManyToManyList = mapperForItem.DummyMainDummyManyToManyList;

        if (mapperDummyMainDummyManyToManyList.Any())
        {
            long[] mapperDummyManyToManyIds = mapperDummyMainDummyManyToManyList
                .Select(x => x.DummyManyToManyId)
                .ToArray();

            if (mapperDummyManyToManyIds.Any())
            {
                var taskForList = dbContext.DummyManyToMany
                    .Where(x => mapperDummyManyToManyIds.Contains(x.Id))
                    .Select(x => new OptionValueObjectWithInt64Id(x.Id, x.Name))
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
        ClientMapperDbContext dbContext,
        Dictionary<long, DummyMainDomainEntity> itemLookup,
        IEnumerable<ClientMapperDummyMainTypeEntity> mapperForItems)
    {
        long[] mapperDummyManyToManyIdsForLookup = mapperForItems
            .SelectMany(x => x.DummyMainDummyManyToManyList)
            .Select(x => x.DummyManyToManyId)
            .Distinct()
            .ToArray();

        if (mapperDummyManyToManyIdsForLookup.Any())
        {
            var taskForLookup = dbContext.DummyManyToMany
                .Where(x => mapperDummyManyToManyIdsForLookup.Contains(x.Id))
                .Select(x => new OptionValueObjectWithInt64Id(x.Id, x.Name))
                .ToDictionaryAsync(x => x.Id);

            var mapperDummyManyToManyLookup = await taskForLookup.ConfigureAwait(false);

            if (mapperDummyManyToManyLookup.Any())
            {
                foreach (var mapperForItem in mapperForItems)
                {
                    if (itemLookup.TryGetValue(mapperForItem.Id, out var item))
                    {
                        long[] mapperDummyManyToManyIds = mapperForItem.DummyMainDummyManyToManyList
                            .Select(x => x.DummyManyToManyId)
                            .ToArray();

                        foreach (long mapperDummyManyToManyId in mapperDummyManyToManyIds)
                        {
                            if (mapperDummyManyToManyLookup.TryGetValue(
                                mapperDummyManyToManyId,
                                out var mapperDummyManyToMany))
                            {
                                item.AddDummyManyToMany(mapperDummyManyToMany);
                            }
                        }
                    }
                }
            }
        }
    }

    private static void LoadDummyManyToOne(DummyMainDomainEntity item, ClientMapperDummyMainTypeEntity mapperForItem)
    {
        var mapperDummyManyToOneList = mapperForItem.DummyManyToOneList;

        if (mapperDummyManyToOneList.Any())
        {
            foreach (var mapperDummyManyToOne in mapperDummyManyToOneList)
            {
                item.AddDummyManyToOne(new OptionValueObjectWithInt64Id(
                    mapperDummyManyToOne.Id,
                    mapperDummyManyToOne.Name));
            }
        }
    }

    private static void LoadDummyManyToOne(
        Dictionary<long, DummyMainDomainEntity> itemLookup,
        IEnumerable<ClientMapperDummyMainTypeEntity> mapperForItems)
    {
        foreach (var mapperForItem in mapperForItems)
        {
            if (itemLookup.TryGetValue(mapperForItem.Id, out var item))
            {
                LoadDummyManyToOne(item, mapperForItem);
            }
        }
    }

    private static void LoadDummyOneToMany(DummyMainDomainEntity item, ClientMapperDummyMainTypeEntity mapperForItem)
    {
        var mapperDummyOneToMany = mapperForItem.DummyOneToMany;

        if (mapperDummyOneToMany != null)
        {
            item.DummyOneToMany = new OptionValueObjectWithInt64Id(
                mapperDummyOneToMany.Id,
                mapperDummyOneToMany.Name);
        }
    }

    private static void LoadDummyOneToMany(
        Dictionary<long, DummyMainDomainEntity> itemLookup,
        IEnumerable<ClientMapperDummyMainTypeEntity> mapperForItems)
    {
        foreach (var mapperForItem in mapperForItems)
        {
            if (itemLookup.TryGetValue( mapperForItem.Id, out var item))
            {
                LoadDummyOneToMany(item, mapperForItem);
            }
        }
    }

    #endregion Private methods
}
