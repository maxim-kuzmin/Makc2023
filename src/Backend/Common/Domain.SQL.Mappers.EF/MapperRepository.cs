// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.SQL.Mappers.EF;

/// <summary>
/// Репозиторий сопоставителя.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public abstract class MapperRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
{
    #region Properties

    /// <inheritdoc/>
    public IUnitOfWork UnitOfWork { get; }

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
