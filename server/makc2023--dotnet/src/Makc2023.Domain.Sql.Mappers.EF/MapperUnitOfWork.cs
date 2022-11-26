// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql;

/// <summary>
/// Единица работы сопоставителя.
/// </summary>
public sealed class MapperUnitOfWork : IUnitOfWork
{
    #region Properties

    private DbContext DbContext { get; init; }

    private IMediator Mediator { get; init; }

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="mediator">Посредник.</param>
    public MapperUnitOfWork(DbContext dbContext, IMediator mediator)
    {
        DbContext = dbContext;
        Mediator = mediator;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public void Dispose()
    {
        DbContext.Dispose();
    }

    /// <inheritdoc/>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return DbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await Mediator.DispatchEventsAsync(DbContext);

        int count = await DbContext.SaveChangesAsync(cancellationToken);

        return count > 0;
    }

    #endregion Public methods
}
