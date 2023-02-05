// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Components.Integration;

/// <summary>
/// Интерфейс шины событий.
/// </summary>
public interface IEventBus
{
    #region Methods

    /// <summary>
    /// Опубликовать событие.
    /// </summary>
    /// <param name="event">Событие.</param>
    void Publish(IntegrationEvent @event);

    /// <summary>
    /// Подписаться на событие.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">Тип события.</typeparam>
    /// <typeparam name="TIntegrationEventHandler">Тип обработчика события.</typeparam>
    void Subscribe<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;

    /// <summary>
    /// Подписаться на динамическое событие.
    /// </summary>
    /// <typeparam name="TIntegrationEventHandler">Тип обработчика события.</typeparam>
    /// <param name="eventName">Имя события.</param>
    void SubscribeDynamic<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler;

    /// <summary>
    /// Отписаться от события.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">Тип события.</typeparam>
    /// <typeparam name="TIntegrationEventHandler">Тип обработчика события.</typeparam>
    void Unsubscribe<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;

    /// <summary>
    /// Отписаться от динамического события
    /// </summary>
    /// <typeparam name="TIntegrationEventHandler">Тип обработчика события.</typeparam>
    /// <param name="eventName">Имя события.</param>
    void UnsubscribeDynamic<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler;

    #endregion Methods
}