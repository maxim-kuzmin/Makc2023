// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Domain.Sql.Mappers.EF.Mediator;

/// <summary>
/// Расширение посредника.
/// </summary>
static class MapperMediatorExtension
{
    #region Public methods

    /// <summary>
    /// Отправить события асинхронно.
    /// </summary>
    /// <param name="mediator">Посредник.</param>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <returns>Задача.</returns>
    public static async Task DispatchEventsAsync(this IMediator mediator, DbContext dbContext)
    {
        var entriesWithEvents = dbContext.ChangeTracker.Entries<IEntity>().Where(HasEvents);

        var events = entriesWithEvents.SelectMany(x => x.Entity.GetEvents()!).ToList();

        entriesWithEvents.ToList().ForEach(x => x.Entity.ClearEvents());

        foreach (var @event in events)
        {
            await mediator.Publish(@event);
        }
    }

    #endregion Public methods

    #region Private methods

    private static bool HasEvents(EntityEntry<IEntity> entry)
    {
        var events = entry.Entity.GetEvents();

        return events is not null && events.Any();
    }

    #endregion Private methods
}
