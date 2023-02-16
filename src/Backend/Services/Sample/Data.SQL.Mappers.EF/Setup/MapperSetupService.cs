// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Setup;

/// <summary>
/// Сервис настройки сопоставителя.
/// </summary>
/// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
public abstract class MapperSetupService<TDbContext> : ISetupService
    where TDbContext : DbContext
{
    #region Public methods

    /// <inheritdoc/>
    public abstract Task MigrateDatabase();

    /// <inheritdoc/>
    public async Task SeedTestData()
    {
        using var dbContext = CreateDbContext();

        using var transaction = await dbContext.Database.BeginTransactionAsync().ConfigureAwait(false);

        bool isAnyDummyMainNotFound = await CheckIfAnyDummyMainNotFound(dbContext).ConfigureAwait(false);

        if (isAnyDummyMainNotFound)
        {
            await SeedTestDummyOneToManyList(dbContext).ConfigureAwait(false);

            var dummyOneToManyIds = GetTestDummyOneToManyIds();

            await SeedTestDummyMainList(dbContext, dummyOneToManyIds).ConfigureAwait(false);

            var dummyMainIds = GetTestDummyMainIds();

            await SeedTestDummyManyToManyList(dbContext).ConfigureAwait(false);

            var dummyManyToManyIds = GetTestDummyManyToManyIds();

            await SeedTestDummyMainDummyManyToManyList(dbContext, dummyMainIds, dummyManyToManyIds).ConfigureAwait(false);

            await SeedTestDummyTreeList(dbContext).ConfigureAwait(false);
        }

        await transaction.CommitAsync().ConfigureAwait(false);
    }

    #endregion Public methods

    #region Protected methods

    /// <summary>
    /// Проверить, найден ли хоть один экземпляр сущности "Фиктивное главное".
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <returns>Задача на проверку.</returns>
    protected abstract Task<bool> CheckIfAnyDummyMainNotFound(TDbContext dbContext);

    /// <summary>
    /// Создать контекст базы данных.
    /// </summary>
    /// <returns>Контекст базы данных.</returns>
    protected abstract TDbContext CreateDbContext();

    /// <summary>
    /// Получить случайный индекс.
    /// </summary>
    /// <typeparam name="T">Тип элемента.</typeparam>
    /// <param name="items">Элементы.</param>
    /// <returns>Индекс.</returns>
    protected static int GetRandomIndex<T>(IEnumerable<T> items)
    {
        return new Random(Guid.NewGuid().GetHashCode()).Next(0, items.Count());
    }

    /// <summary>
    /// Получить идентификаторы экземпляров сущности "Фиктивное главное".
    /// </summary>
    /// <returns>Идентификаторы.</returns>
    protected abstract IEnumerable<long> GetTestDummyMainIds();

    /// <summary>
    /// Получить идентификаторы экземпляров сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    /// <returns>Идентификаторы.</returns>
    protected abstract IEnumerable<long> GetTestDummyManyToManyIds();

    /// <summary>
    /// Получить идентификаторы экземпляров сущности "Фиктивное отношение один ко многим".
    /// </summary>
    /// <returns>Идентификаторы.</returns>
    protected abstract IEnumerable<long> GetTestDummyOneToManyIds();

    /// <summary>
    /// Засеять список экземпляров сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <returns>Задача на засеивание.</returns>
    protected abstract Task SeedTestDummyManyToManyList(TDbContext dbContext);

    /// <summary>
    /// Засеять список экземпляров сущности "Фиктивное отношение один ко многим".
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <returns>Задача на засеивание.</returns>
    protected abstract Task SeedTestDummyOneToManyList(TDbContext dbContext);

    /// <summary>
    /// Засеять список экземпляров сущности "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="dummyMainIds">Идентификаторы экземпляров сущности "Фиктивное главное".</param>
    /// <param name="dummyManyToManyIds">Идентификаторы экземпляров сущности "Фиктивное отношение многие ко многим".</param>
    /// <returns>Задача на засеивание.</returns>
    protected abstract Task SeedTestDummyMainDummyManyToManyList(
        TDbContext dbContext,
        IEnumerable<long> dummyMainIds,
        IEnumerable<long> dummyManyToManyIds);

    /// <summary>
    /// Засеять список экземпляров сущности "Фиктивное дерево".
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <returns>Задача на засеивание.</returns>
    protected abstract Task SeedTestDummyTreeList(TDbContext dbContext);

    /// <summary>
    /// Засеять список экземпляров сущности "Фиктивное главное".
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="dummyOneToManyIds">Идентификаторы экземпляров сущности "Фиктивное отношение один ко многим".</param>
    /// <returns>Задача на засеивание.</returns>
    protected abstract Task SeedTestDummyMainList(TDbContext dbContext, IEnumerable<long> dummyOneToManyIds);

    #endregion Protected methods
}
