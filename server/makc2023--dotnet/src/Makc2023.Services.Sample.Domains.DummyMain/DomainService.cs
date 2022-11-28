// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain;

/// <summary>
/// Сервис домена.
/// </summary>
public class DomainService : IDomainService
{
    #region Properties

    private IMapperDbContextFactory DbContextFactory { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContextFactory">Фабрика контекста базы данных.</param>
    public DomainService(IMapperDbContextFactory dbContextFactory)
    {
        DbContextFactory = dbContextFactory;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task<DomainItemGetOperationOutput?> GetItem(DomainItemGetOperationInput input)
    {
        DomainItemGetOperationOutput? result = null;

        using var dbContext = DbContextFactory.CreateDbContext();

        var entity = await dbContext.DummyMain!
            .Include(x => x.DummyOneToMany)
            .Include(x => x.DummyMainDummyManyToManyList)
            .ApplyFiltering(input)
            .FirstOrDefaultAsync();

        if (entity != null)
        {
            result = CreateItem(entity);

            if (result.DummyMainDummyManyToManyList != null)
            {
                long[] ids = result.DummyMainDummyManyToManyList
                    .Select(x => x.DummyManyToManyId)
                    .ToArray();

                if (ids.Any())
                {
                    var enities = await dbContext.DummyManyToMany!
                        .Where(x => ids.Contains(x.Id))
                        .ToArrayAsync();

                    if (enities.Any())
                    {
                        InitItemDummyManyToMany(result, enities);
                    }
                }
            }
        }

        return result;
    }

    /// <inheritdoc/>
    public async Task<DomainListGetOperationOutput> GetList(DomainListGetOperationInput input)
    {
        var result = new DomainListGetOperationOutput();

        using var dbContext = DbContextFactory.CreateDbContext();
        using var dbContextForTotalCount = DbContextFactory.CreateDbContext();

        var itemsQuery = dbContext.DummyMain!
            .Include(x => x.DummyOneToMany)
            .Include(x => x.DummyMainDummyManyToManyList)
            .ApplyFiltering(input)
            .ApplySorting(input)
            .ApplyPagination(input);

        var totalCountQuery = dbContextForTotalCount.DummyMain!
            .ApplyFiltering(input);

        var itemsTask = itemsQuery.ToArrayAsync();
        var totalCountTask = totalCountQuery.CountAsync();

        await Task.WhenAll(itemsTask, totalCountTask);

        result.Items = itemsTask.Result.Select(CreateItem).ToArray();
        result.TotalCount = totalCountTask.Result;

        if (result.Items.Any())
        {
            long[] ids = result.Items
                .Where(x => x.DummyMainDummyManyToManyList != null)
                .SelectMany(x => x.DummyMainDummyManyToManyList!)
                .Select(x => x.DummyManyToManyId)
                .Distinct()
                .ToArray();

            if (ids.Any())
            {
                var lookup = await dbContext.DummyManyToMany!
                    .Where(x => ids.Contains(x.Id))
                    .ToDictionaryAsync(x => x.Id);

                if (lookup.Any())
                {
                    foreach (var item in result.Items)
                    {
                        if (item.DummyMainDummyManyToManyList != null)
                        {
                            InitItemDummyManyToMany(item, lookup);
                        }
                    }
                }
            }
        }

        return result;
    }

    #endregion Public methods

    #region Private methods

    private static DomainItemGetOperationOutput CreateItem(MapperDummyMainTypeEntity entity)
    {
        var result = new DomainItemGetOperationOutput
        {
            DummyMain = entity.ToEntity(),
            DummyOneToMany = entity.DummyOneToMany!.ToEntity()
        };

        if (entity.DummyMainDummyManyToManyList.Any())
        {
            result.DummyMainDummyManyToManyList = entity.DummyMainDummyManyToManyList
                .Select(x => x.ToEntity())
                .ToArray();
        }

        return result;
    }

    private static void InitItemDummyManyToMany(
        DomainItemGetOperationOutput item,
        IEnumerable<MapperDummyManyToManyTypeEntity> enities
        )
    {
        item.DummyManyToManyList = enities
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Id)
            .Select(x => x.ToEntity())
            .ToArray();
    }

    private static void InitItemDummyManyToMany(
        DomainItemGetOperationOutput item,
        IDictionary<long, MapperDummyManyToManyTypeEntity> lookup
        )
    {
        long[] ids = item.DummyMainDummyManyToManyList!
            .Select(x => x.DummyManyToManyId)
            .ToArray();

        var entities = new List<MapperDummyManyToManyTypeEntity>();

        foreach (long id in ids)
        {
            if (lookup.TryGetValue(id, out MapperDummyManyToManyTypeEntity? entity))
            {
                entities.Add(entity);
            }
        }

        if (entities.Any())
        {
            InitItemDummyManyToMany(item, entities);
        }
    }

    #endregion Private methods
}
