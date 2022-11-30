// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Components.Integration;

/// <summary>
/// Менеджер подписок шины событий в памяти.
/// </summary>
public partial class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
{
    #region Fields

    private readonly Dictionary<string, List<SubscriptionInfo>> _handlers;

    private readonly List<Type> _eventTypes;

    #endregion Fields

    #region Properties

    /// <inheritdoc/>
    public bool IsEmpty => _handlers is { Count: 0 };

    #endregion Properties

    #region Events

    /// <inheritdoc/>
    public event EventHandler<string>? EventRemoved;

    #endregion Events    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    public InMemoryEventBusSubscriptionsManager()
    {
        _handlers = new Dictionary<string, List<SubscriptionInfo>>();
        _eventTypes = new List<Type>();
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public void Clear() => _handlers.Clear();

    /// <inheritdoc/>
    public void AddDynamicSubscription<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler
    {
        DoAddSubscription(typeof(TIntegrationEventHandler), eventName, isDynamic: true);
    }

    /// <inheritdoc/>
    public void AddSubscription<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        string eventName = GetEventKey<TIntegrationEvent>();

        DoAddSubscription(typeof(TIntegrationEventHandler), eventName, isDynamic: false);

        if (!_eventTypes.Contains(typeof(TIntegrationEvent)))
        {
            _eventTypes.Add(typeof(TIntegrationEvent));
        }
    }

    /// <inheritdoc/>
    public void RemoveDynamicSubscription<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler
    {
        var handlerToRemove = FindDynamicSubscriptionToRemove<TIntegrationEventHandler>(eventName);

        if (handlerToRemove is not null)
        {
            DoRemoveHandler(eventName, handlerToRemove);
        }
    }

    /// <inheritdoc/>
    public void RemoveSubscription<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        var handlerToRemove = FindSubscriptionToRemove<TIntegrationEvent, TIntegrationEventHandler>();

        string eventName = GetEventKey<TIntegrationEvent>();

        if (handlerToRemove is not null)
        {
            DoRemoveHandler(eventName, handlerToRemove);
        }
    }

    /// <inheritdoc/>
    public IEnumerable<SubscriptionInfo> GetHandlersForEvent<TIntegrationEvent>()
        where TIntegrationEvent : IntegrationEvent
    {
        string key = GetEventKey<TIntegrationEvent>();

        return GetHandlersForEvent(key);
    }

    /// <inheritdoc/>
    public IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName) => _handlers[eventName];

    /// <inheritdoc/>
    public bool HasSubscriptionsForEvent<TIntegrationEvent>() where TIntegrationEvent : IntegrationEvent
    {
        string key = GetEventKey<TIntegrationEvent>();

        return HasSubscriptionsForEvent(key);
    }

    /// <inheritdoc/>
    public bool HasSubscriptionsForEvent(string eventName) => _handlers.ContainsKey(eventName);

    /// <inheritdoc/>
    public Type? GetEventTypeByName(string eventName) => _eventTypes.SingleOrDefault(t => t.Name == eventName);

    /// <inheritdoc/>
    public string GetEventKey<TIntegrationEvent>()
    {
        return typeof(TIntegrationEvent).Name;
    }

    #endregion Public methods

    #region Private methods

    private void DoAddSubscription(Type handlerType, string eventName, bool isDynamic)
    {
        if (!HasSubscriptionsForEvent(eventName))
        {
            _handlers.Add(eventName, new List<SubscriptionInfo>());
        }

        if (_handlers[eventName].Any(s => s.HandlerType == handlerType))
        {
            throw new ArgumentException(
                $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
        }

        if (isDynamic)
        {
            _handlers[eventName].Add(SubscriptionInfo.Dynamic(handlerType));
        }
        else
        {
            _handlers[eventName].Add(SubscriptionInfo.Typed(handlerType));
        }
    }

    private void DoRemoveHandler(string eventName, SubscriptionInfo subToRemove)
    {
        var subs = _handlers[eventName];

        subs.Remove(subToRemove);

        if (!subs.Any())
        {
            _handlers.Remove(eventName);

            var eventType = _eventTypes.SingleOrDefault(e => e.Name == eventName);
            
            if (eventType != null)
            {
                _eventTypes.Remove(eventType);
            }
            
            RaiseOnEventRemoved(eventName);
        }
    }

    private void RaiseOnEventRemoved(string eventName)
    {
        var handler = EventRemoved;

        handler?.Invoke(this, eventName);
    }

    private SubscriptionInfo? FindDynamicSubscriptionToRemove<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler
    {
        return DoFindSubscriptionToRemove(eventName, typeof(TIntegrationEventHandler));
    }

    private SubscriptionInfo? FindSubscriptionToRemove<TIntegrationEvent, TIntegrationEventHandler>()
            where TIntegrationEvent : IntegrationEvent
            where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        string eventName = GetEventKey<TIntegrationEvent>();

        return DoFindSubscriptionToRemove(eventName, typeof(TIntegrationEventHandler));
    }

    private SubscriptionInfo? DoFindSubscriptionToRemove(string eventName, Type handlerType)
    {
        if (!HasSubscriptionsForEvent(eventName))
        {
            return null;
        }

        return _handlers[eventName].SingleOrDefault(s => s.HandlerType == handlerType);

    }

    #endregion Private methods
}
