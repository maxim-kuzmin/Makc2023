// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.SQL.Mappers.EF;

public abstract class MapperRepository<T> : IRepository<T> where T : IAggregateRoot
{
    #region Properties

    /// <inheritdoc/>
    public IUnitOfWork UnitOfWork { get; init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="mediator">Посредник.</param>
    public MapperRepository(DbContext dbContext, IMediator mediator)
    {
        UnitOfWork = dbContext.CreateUnitOfWork(mediator);
    }

    #endregion Constructors
}
