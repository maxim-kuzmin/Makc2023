// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Components.Integration;

/// <summary>
/// Интерфейс менеджера подписок шины событий.
/// </summary>
public interface IEventBusSubscriptionsManager
{    
    #region Properties

    /// <summary>
    /// Признак того, что список обработчиков событий пуст.
    /// </summary>
    bool IsEmpty { get; }

    #endregion Properties

    #region Events

    /// <summary>
    /// Событие, возникающее в случае опустошения списка обработчиков события.
    /// </summary>
    event EventHandler<string>? EventRemoved;

    #endregion Events    

    #region Methods

    /// <summary>
    /// Очистить список обработчиков событий.
    /// </summary>
    void Clear();

    /// <summary>
    /// Добавить подписку на динамическое событие.
    /// </summary>
    /// <typeparam name="TIntegrationEventHandler">Тип обработчика события.</typeparam>
    /// <param name="eventName">Имя события.</param>
    void AddDynamicSubscription<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler;

    /// <summary>
    /// Добавить подписку на событие.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">Тип события.</typeparam>
    /// <typeparam name="TIntegrationEventHandler">Тип обработчика события.</typeparam>
    void AddSubscription<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;

    /// <summary>
    /// Удалить подписку на динамическое событие.
    /// </summary>
    /// <typeparam name="TIntegrationEventHandler">Тип обработчика события.</typeparam>
    /// <param name="eventName">Имя события.</param>
    void RemoveDynamicSubscription<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler;

    /// <summary>
    /// Удалить подписку на событие.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">Тип события.</typeparam>
    /// <typeparam name="TIntegrationEventHandler">Тип обработчика события.</typeparam>
    void RemoveSubscription<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>;

    /// <summary>
    /// Получить обработчики для события по его типу.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">Тип события.</typeparam>
    /// <returns>Обработчики события.</returns>
    IEnumerable<SubscriptionInfo> GetHandlersForEvent<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent;

    /// <summary>
    /// Получить обработчики для события по его имени.
    /// </summary>
    /// <param name="eventName">Имя события.</param>
    /// <returns>Обработчики события.</returns>
    IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

    /// <summary>
    /// Проверить, существуют ли подписки для события по его типу.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">Тип события.</typeparam>
    /// <returns>Признак существования подписок.</returns>
    bool HasSubscriptionsForEvent<TIntegrationEvent>() where TIntegrationEvent : IntegrationEvent;

    /// <summary>
    /// Проверить, существуют ли подписки для события по его имени.
    /// </summary>
    /// <param name="eventName">Имя события.</param>
    /// <returns>Признак существования подписок.</returns>
    bool HasSubscriptionsForEvent(string eventName);

    /// <summary>
    /// Получить тип события по его имени.
    /// </summary>
    /// <param name="eventName">Имя события.</param>
    /// <returns>Тип события.</returns>
    Type? GetEventTypeByName(string eventName);

    /// <summary>
    /// Получить ключ события по его типу.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">Тип события.</typeparam>
    /// <returns>Ключ события.</returns>
    string GetEventKey<TIntegrationEvent>();

    #endregion Methods
}
