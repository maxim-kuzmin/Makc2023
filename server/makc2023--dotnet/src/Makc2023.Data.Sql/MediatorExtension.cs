// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql;

/// <summary>
/// Расширение посредника.
/// </summary>
static class MediatorExtension
{
    #region Public methods

    /// <summary>
    /// Отправить события асинхронно.
    /// </summary>
    /// <param name="mediator">Посредник.</param>
    /// <param name="unitOfWork">Единица работы.</param>
    /// <returns>Задача.</returns>
    public static async Task DispatchEventsAsync(this IMediator mediator, UnitOfWork unitOfWork)
    {
        var entriesWithEvents = unitOfWork.ChangeTracker.Entries<IEntity>().Where(HasEvents);

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
