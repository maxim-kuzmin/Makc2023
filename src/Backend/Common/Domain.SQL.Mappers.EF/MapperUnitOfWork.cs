// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2023.Backend.Common.Domain.SQL.Mappers.EF.Mediator;

namespace Makc2023.Backend.Common.Data.SQL;

/// <summary>
/// Единица работы сопоставителя.
/// </summary>
public sealed class MapperUnitOfWork : IUnitOfWork
{
    #region Fields

    private readonly DbContext _dbContext;

    private readonly IMediator _mediator;

    #endregion Fields    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="mediator">Посредник.</param>
    public MapperUnitOfWork(DbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public void Dispose()
    {
        _dbContext.Dispose();
    }

    /// <inheritdoc/>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchEventsAsync(_dbContext).ConfigureAwait(false);

        int count = await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return count > 0;
    }

    #endregion Public methods
}
