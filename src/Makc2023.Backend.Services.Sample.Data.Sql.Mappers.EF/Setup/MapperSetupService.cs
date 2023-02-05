// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Setup;

/// <summary>
/// Сервис настройки сопоставителя.
/// </summary>
public class MapperSetupService : ISetupService
{
    #region Properties

    private IProvider ClientProvider { get; }

    private TypesOptions EntitiesOptions { get; }

    private IMapperDbContextFactory MapperDbFactory { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>        
    /// <param name="сlientProvider">Поставщик клиента.</param>
    /// <param name="typesOptions">Параметры сущностей.</param>        
    /// <param name="mapperDbFactory">Фабрика базы данных сопоставителя.</param>
    public MapperSetupService(
        IProvider сlientProvider,
        TypesOptions typesOptions,
        IMapperDbContextFactory mapperDbFactory
        )
    {
        ClientProvider = сlientProvider;
        EntitiesOptions = typesOptions;
        MapperDbFactory = mapperDbFactory;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public async Task MigrateDatabase()
    {
        using var dbContext = MapperDbFactory.CreateDbContext();

        await dbContext.Database.MigrateAsync();
    }

    /// <inheritdoc/>
    public async Task SeedTestData()
    {
        using var dbContext = MapperDbFactory.CreateDbContext();

        using var transaction = await dbContext.Database.BeginTransactionAsync();

        bool isOk = await dbContext.DummyMain.AnyAsync();

        if (!isOk)
        {
            var dummyOneToManyList = await SeedTestDummyOneToManyList(dbContext);

            var dummyMainList = await SeedTestDummyMainList(dbContext, dummyOneToManyList);

            var dummyManyToManyList = await SeedTestDummyManyToManyList(dbContext);

            await SeedTestDummyMainDummyManyToManyList(dbContext, dummyMainList, dummyManyToManyList);

            await SeedTestDummyTreeList(dbContext);
        }

        await transaction.CommitAsync();
    }

    #endregion Public methods

    #region Private methods

    private TreeTriggerCommandBuilder CreateQueryTreeTriggerBuilder(
        TriggerCommandAction action)
    {
        var result = ClientProvider.CreateQueryTreeTriggerBuilder();

        result.Action = action;

        InitQueryBuilder(result, EntitiesOptions.DummyTreeLink, EntitiesOptions.DummyTree);

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

    private static MapperDummyMainTypeEntity CreateTestDummyMain(
        long index,
        IEnumerable<MapperDummyOneToManyTypeEntity> dummyOneToManyList)
    {
        bool isEven = index % 2 == 0;

        int day = isEven ? 2 : 1;

        var localTime = new DateTime(2018, 03, day, 06, 32, 00);

        var dateAndOffsetLocal = new DateTimeOffset(
            localTime,
            TimeZoneInfo.Local.GetUtcOffset(localTime)
            );

        int dummyOneToManyIndex = GetRandomIndex(dummyOneToManyList);

        return new MapperDummyMainTypeEntity
        {
            Name = $"Name-{index}",
            DummyOneToManyId = dummyOneToManyList.ElementAt(dummyOneToManyIndex).Id,
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

    private static List<MapperDummyMainDummyManyToManyTypeEntity> CreateTestDummyMainDummyManyToManyList(
        MapperDummyMainTypeEntity dummyMain,
        IEnumerable<MapperDummyManyToManyTypeEntity> dummyManyToManyList)
    {
        var result = new List<MapperDummyMainDummyManyToManyTypeEntity>();

        foreach (var dummyManyToMany in dummyManyToManyList)
        {
            bool isEven = GetRandomIndex(dummyManyToManyList) % 2 == 0;

            if (isEven) continue;

            var dummyMainDummyManyToMany = new MapperDummyMainDummyManyToManyTypeEntity
            {
                DummyMainId = dummyMain.Id,
                DummyManyToManyId = dummyManyToMany.Id
            };

            result.Add(dummyMainDummyManyToMany);
        }

        if (!result.Any())
        {
            int index = GetRandomIndex(dummyManyToManyList);

            var dummyMainDummyManyToMany = new MapperDummyMainDummyManyToManyTypeEntity
            {
                DummyMainId = dummyMain.Id,
                DummyManyToManyId = dummyManyToManyList.ElementAt(index).Id
            };

            result.Add(dummyMainDummyManyToMany);
        }

        return result;
    }

    private static MapperDummyManyToManyTypeEntity CreateTestDummyManyToMany(long index)
    {
        return new MapperDummyManyToManyTypeEntity
        {
            Name = $"Name-{index}"
        };
    }

    private static MapperDummyOneToManyTypeEntity CreateTestDummyOneToMany(long index)
    {
        return new MapperDummyOneToManyTypeEntity
        {
            Name = $"Name-{index}"
        };
    }

    private static MapperDummyTreeTypeEntity CreateTestDummyTree(
        IEnumerable<int> indexes,
        long? parentId)
    {
        string suffix = indexes.Any() ? "-" + string.Join("-", indexes) : string.Empty;

        return new MapperDummyTreeTypeEntity
        {
            Name = $"Name{suffix}",
            ParentId = parentId
        };
    }

    private static int GetRandomIndex<T>(IEnumerable<T> items)
    {
        return new Random(Guid.NewGuid().GetHashCode()).Next(0, items.Count());
    }

    private async Task SaveTestDummyTreeList(
        MapperDbContext dbContext,
        List<MapperDummyTreeTypeEntity> dummyTreeList,
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

            await dbContext.SaveChangesAsync();

            await SaveTestDummyTreeList(dbContext, dummyTreeList, indexes, dummyTree.Id);

            indexes.RemoveAt(indexes.Count - 1);
        }
    }

    private static async Task<IEnumerable<MapperDummyMainTypeEntity>> SeedTestDummyMainList(
        MapperDbContext dbContext,
        IEnumerable<MapperDummyOneToManyTypeEntity> dummyOneToManyList)
    {
        var result = Enumerable.Range(1, 100)
            .Select(index => CreateTestDummyMain(index, dummyOneToManyList))
            .ToArray();

        dbContext.DummyMain!.AddRange(result);

        await dbContext.SaveChangesAsync();

        return result;
    }

    private static async Task<IEnumerable<MapperDummyMainDummyManyToManyTypeEntity>> SeedTestDummyMainDummyManyToManyList(
        MapperDbContext dbContext,
        IEnumerable<MapperDummyMainTypeEntity> dummyMainList,
        IEnumerable<MapperDummyManyToManyTypeEntity> dummyManyToManyList)
    {
        var result = new List<MapperDummyMainDummyManyToManyTypeEntity>();

        foreach (var dummyMain in dummyMainList)
        {
            var dummyMainDummyManyToManyList = CreateTestDummyMainDummyManyToManyList(
                dummyMain,
                dummyManyToManyList);

            if (dummyMainDummyManyToManyList.Any())
            {
                result.AddRange(dummyMainDummyManyToManyList);
            }
        }

        dbContext.AddRange(result);

        await dbContext.SaveChangesAsync();

        return result;
    }

    private static async Task<IEnumerable<MapperDummyManyToManyTypeEntity>> SeedTestDummyManyToManyList(
        MapperDbContext dbContext)
    {
        var result = Enumerable.Range(1, 10)
            .Select(index => CreateTestDummyManyToMany(index))
            .ToArray();

        dbContext.DummyManyToMany!.AddRange(result);

        await dbContext.SaveChangesAsync();

        return result;
    }

    private static async Task<IEnumerable<MapperDummyOneToManyTypeEntity>> SeedTestDummyOneToManyList(
        MapperDbContext dbContext)
    {
        var result = Enumerable.Range(1, 10)
            .Select(index => CreateTestDummyOneToMany(index))
            .ToArray();

        dbContext.DummyOneToMany!.AddRange(result);

        await dbContext.SaveChangesAsync();

        return result;
    }

    private async Task<IEnumerable<MapperDummyTreeTypeEntity>> SeedTestDummyTreeList(
        MapperDbContext dbContext)
    {
        var result = new List<MapperDummyTreeTypeEntity>();

        await SaveTestDummyTreeList(dbContext, result, new List<int>(), null);

        var queryTreeTriggerBuilder = CreateQueryTreeTriggerBuilder(TriggerCommandAction.None);

        string sql = queryTreeTriggerBuilder.GetResultSql();

        await dbContext.Database.ExecuteSqlRawAsync(sql);

        return result;
    }

    #endregion Private methods
}
