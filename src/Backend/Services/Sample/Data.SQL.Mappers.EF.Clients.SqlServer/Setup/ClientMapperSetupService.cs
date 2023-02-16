// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Setup;

/// <summary>
/// Сервис настройки сопоставителя клиента.
/// </summary>
public class ClientMapperSetupService : MapperSetupService<ClientMapperDbContext>
{
    #region Fields

    private readonly IClientMapperDbContextFactory _dbContextFactory;

    private readonly IProvider _provider;

    private readonly TypesOptions _typesOptions;

    #endregion Fields

    #region Properties

    private IEnumerable<ClientMapperDummyMainTypeEntity> DummyMainList { get; set; } = null!;

    private IEnumerable<ClientMapperDummyManyToManyTypeEntity> DummyManyToManyList { get; set; } = null!;

    private IEnumerable<ClientMapperDummyOneToManyTypeEntity> DummyOneToManyList { get; set; } = null!;

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContextFactory">Фабрика контекста базы данных.</param>
    /// <param name="provider">Поставщик.</param>
    /// <param name="typesOptions">Параметры сущностей.</param>            
    public ClientMapperSetupService(
        IClientMapperDbContextFactory dbContextFactory,
        IProvider provider,
        TypesOptions typesOptions)
    {
        _dbContextFactory = dbContextFactory;
        _provider = provider;
        _typesOptions = typesOptions;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public override Task MigrateDatabase()
    {
        var dbContext = CreateDbContext();

        return dbContext.MigrateAsync();
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override async Task<bool> CheckIfAnyDummyMainNotFound(ClientMapperDbContext dbContext)
    {
        bool isFound = await dbContext.DummyMain.AnyAsync().ConfigureAwait(false);

        return !isFound;
    }

    /// <inheritdoc/>
    protected sealed override ClientMapperDbContext CreateDbContext()
    {
        return _dbContextFactory.CreateDbContext();
    }

    /// <inheritdoc/>
    protected sealed override IEnumerable<long> GetTestDummyMainIds()
    {
        return DummyMainList.Select(x => x.Id);
    }

    /// <inheritdoc/>
    protected sealed override IEnumerable<long> GetTestDummyManyToManyIds()
    {
        return DummyManyToManyList.Select(x => x.Id);
    }

    /// <inheritdoc/>
    protected sealed override IEnumerable<long> GetTestDummyOneToManyIds()
    {
        return DummyOneToManyList.Select(x => x.Id);
    }

    /// <inheritdoc/>
    protected sealed override async Task SeedTestDummyManyToManyList(ClientMapperDbContext dbContext)
    {
        DummyManyToManyList = Enumerable.Range(1, 10)
            .Select(index => CreateTestDummyManyToMany(index))
            .ToArray();

        dbContext.DummyManyToMany.AddRange(DummyManyToManyList);

        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected sealed override async Task SeedTestDummyOneToManyList(ClientMapperDbContext dbContext)
    {
        DummyOneToManyList = Enumerable.Range(1, 10)
            .Select(index => CreateTestDummyOneToMany(index))
            .ToArray();

        dbContext.DummyOneToMany.AddRange(DummyOneToManyList);

        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected sealed override async Task SeedTestDummyMainDummyManyToManyList(
        ClientMapperDbContext dbContext,
        IEnumerable<long> dummyMainIds,
        IEnumerable<long> dummyManyToManyIds)
    {
        var result = new List<ClientMapperDummyMainDummyManyToManyTypeEntity>();

        foreach (long dummyMainId in dummyMainIds)
        {
            var dummyMainDummyManyToManyList = CreateTestDummyMainDummyManyToManyList(
                dummyMainId,
                dummyManyToManyIds);

            if (dummyMainDummyManyToManyList.Any())
            {
                result.AddRange(dummyMainDummyManyToManyList);
            }
        }

        dbContext.AddRange(result);

        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected sealed override async Task SeedTestDummyTreeList(ClientMapperDbContext dbContext)
    {
        var result = new List<ClientMapperDummyTreeTypeEntity>();

        await SaveTestDummyTreeList(dbContext, result, new List<int>(), null).ConfigureAwait(false);

        var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(TriggerCommandAction.None);

        string sql = queryTreeTriggerBuilder.GetResultSql();

        await dbContext.Database.ExecuteSqlRawAsync(sql).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    protected sealed override async Task SeedTestDummyMainList(
        ClientMapperDbContext dbContext,
        IEnumerable<long> dummyOneToManyIds)
    {
        var result = Enumerable.Range(1, 100)
            .Select(index => CreateTestDummyMain(index, dummyOneToManyIds))
            .ToArray();

        dbContext.DummyMain!.AddRange(result);

        await dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    #endregion Protected methods

    #region Private methods

    private TreeTriggerCommandBuilder CreateQueryTreeTriggerBuilder(
        TriggerCommandAction action)
    {
        var result = _provider.CreateQueryTreeTriggerBuilder();

        result.Action = action;

        InitQueryBuilder(result, _typesOptions.DummyTreeLink, _typesOptions.DummyTree);

        return result;
    }

    private static void InitQueryBuilder(
        TreeTriggerCommandBuilder builder,
        DummyTreeLinkTypeOptions? linkOptions,
        DummyTreeTypeOptions? treeOptions)
    {
        if (linkOptions is null)
        {
            throw new ArgumentNullException(nameof(linkOptions));
        }

        if (treeOptions is null)
        {
            throw new ArgumentNullException(nameof(treeOptions));
        }

        builder.LinkTableFieldNameForId = linkOptions.DbColumnForId;
        builder.LinkTableFieldNameForParentId = linkOptions.DbColumnForParentId;

        builder.LinkTableNameWithoutSchema = linkOptions.DbTable;
        builder.LinkTableSchema = linkOptions.DbSchema;

        builder.TreeTableFieldNameForId = treeOptions.DbColumnForId;
        builder.TreeTableFieldNameForParentId = treeOptions.DbColumnForParentId;
        builder.TreeTableFieldNameForTreeChildCount = treeOptions.DbColumnForTreeChildCount;
        builder.TreeTableFieldNameForTreeDescendantCount = treeOptions.DbColumnForTreeDescendantCount;
        builder.TreeTableFieldNameForTreeLevel = treeOptions.DbColumnForTreeLevel;
        builder.TreeTableFieldNameForTreePath = treeOptions.DbColumnForTreePath;
        builder.TreeTableFieldNameForTreePosition = treeOptions.DbColumnForTreePosition;
        builder.TreeTableFieldNameForTreeSort = treeOptions.DbColumnForTreeSort;

        builder.TreeTableNameWithoutSchema = treeOptions.DbTable;
        builder.TreeTableSchema = treeOptions.DbSchema;
    }

    private static ClientMapperDummyMainTypeEntity CreateTestDummyMain(
        long index,
        IEnumerable<long> dummyOneToManyIds)
    {
        bool isEven = index % 2 == 0;

        int day = isEven ? 2 : 1;

        var localTime = new DateTime(2018, 03, day, 06, 32, 00);

        var dateAndOffsetLocal = new DateTimeOffset(
            localTime,
            TimeZoneInfo.Local.GetUtcOffset(localTime)
            );

        int dummyOneToManyIndex = GetRandomIndex(dummyOneToManyIds);

        return new ClientMapperDummyMainTypeEntity
        {
            Name = $"Name-{index}",
            DummyOneToManyId = dummyOneToManyIds.ElementAt(dummyOneToManyIndex),
            PropBoolean = isEven,
            PropBooleanNullable = isEven ? new bool?(!isEven) : null,
            PropDate = new DateTime(2018, 01, day),
            PropDateNullable = isEven ? new DateTime?(new DateTime(2018, 02, day)) : null,
            PropDateTime = dateAndOffsetLocal,
            PropDateTimeNullable = isEven ? new DateTimeOffset?(dateAndOffsetLocal) : null,
            PropDecimal = 1000M + index + index / 100M,
            PropDecimalNullable = isEven ? new decimal?(2000M + index + index / 200M) : null,
            PropInt32 = 1000 + (int)index,
            PropInt32Nullable = isEven ? new int?(1000 + (int)index) : null,
            PropInt64 = 3000 + index,
            PropInt64Nullable = isEven ? new long?(3000 + index) : null,
            PropString = $"PropString-{index}",
            PropStringNullable = isEven ? $"PropStringNullable-{index}" : null
        };
    }

    private static List<ClientMapperDummyMainDummyManyToManyTypeEntity> CreateTestDummyMainDummyManyToManyList(
        long dummyMainId,
        IEnumerable<long> dummyManyToManyIds)
    {
        var result = new List<ClientMapperDummyMainDummyManyToManyTypeEntity>();

        foreach (long dummyManyToManyId in dummyManyToManyIds)
        {
            bool isEven = GetRandomIndex(dummyManyToManyIds) % 2 == 0;

            if (isEven) continue;

            var dummyMainDummyManyToMany = new ClientMapperDummyMainDummyManyToManyTypeEntity
            {
                DummyMainId = dummyMainId,
                DummyManyToManyId = dummyManyToManyId
            };

            result.Add(dummyMainDummyManyToMany);
        }

        if (!result.Any())
        {
            int index = GetRandomIndex(dummyManyToManyIds);

            var dummyMainDummyManyToMany = new ClientMapperDummyMainDummyManyToManyTypeEntity
            {
                DummyMainId = dummyMainId,
                DummyManyToManyId = dummyManyToManyIds.ElementAt(index)
            };

            result.Add(dummyMainDummyManyToMany);
        }

        return result;
    }

    private static ClientMapperDummyManyToManyTypeEntity CreateTestDummyManyToMany(long index)
    {
        return new ClientMapperDummyManyToManyTypeEntity
        {
            Name = $"Name-{index}"
        };
    }

    private static ClientMapperDummyOneToManyTypeEntity CreateTestDummyOneToMany(long index)
    {
        return new ClientMapperDummyOneToManyTypeEntity
        {
            Name = $"Name-{index}"
        };
    }

    private static ClientMapperDummyTreeTypeEntity CreateTestDummyTree(
        IEnumerable<int> indexes,
        long? parentId)
    {
        string suffix = indexes.Any() ? "-" + string.Join("-", indexes) : string.Empty;

        return new ClientMapperDummyTreeTypeEntity
        {
            Name = $"Name{suffix}",
            ParentId = parentId
        };
    }

    private async Task SaveTestDummyTreeList(
        ClientMapperDbContext dbContext,
        List<ClientMapperDummyTreeTypeEntity> dummyTreeList,
        List<int> parentIndexes,
        long? parentId)
    {
        if (parentIndexes.Count == 5)
        {
            return;
        }

        var indexes = new List<int>();

        if (parentIndexes.Any())
        {
            indexes.AddRange(parentIndexes);
        }

        for (int index = 1; index < 4; index++)
        {
            indexes.Add(index);

            var dummyTree = CreateTestDummyTree(indexes, parentId);

            dummyTreeList.Add(dummyTree);

            dbContext.DummyTree!.Add(dummyTree);

            await dbContext.SaveChangesAsync().ConfigureAwait(false);

            await SaveTestDummyTreeList(dbContext, dummyTreeList, indexes, dummyTree.Id).ConfigureAwait(false);

            indexes.RemoveAt(indexes.Count - 1);
        }
    }

    #endregion Private methods
}
