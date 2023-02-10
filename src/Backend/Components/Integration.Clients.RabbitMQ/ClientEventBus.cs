// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Components.Integration.Clients.RabbitMQ;

/// <summary>
/// Шина событий клиента.
/// </summary>
public sealed class ClientEventBus : IEventBus, IDisposable
{
    #region Constants

    public const string BROKER_NAME = "Makc2003_event_bus";
    public const string AUTOFAC_SCOPE_NAME = "Makc2003_event_bus";

    #endregion Constants

    #region Fields

    private readonly IClientConnection _connection;
    private readonly ILogger _logger;
    private readonly IEventBusSubscriptionsManager _subsManager;
    private readonly IServiceProvider _serviceProvider;
    private readonly int _retryCount;

    private IModel _consumerChannel;
    private string _queueName;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="connection">Подключение.</param>
    /// <param name="logger">Регистратор.</param>
    /// <param name="serviceProvider">Поставщик сервисов.</param>
    /// <param name="subsManager">Менеджер подписок шины событий.</param>
    /// <param name="queueName">Имя очереди.</param>
    /// <param name="retryCount">Количество повторов отправки событий в шину в случае неудачи.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public ClientEventBus(
        IClientConnection connection,
        ILogger<ClientEventBus> logger,
        IServiceProvider serviceProvider,
        IEventBusSubscriptionsManager subsManager,
        string queueName,
        int retryCount = 5)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _subsManager = subsManager ?? new InMemoryEventBusSubscriptionsManager();
        _queueName = queueName;
        _consumerChannel = CreateConsumerChannel();
        _serviceProvider = serviceProvider;
        _retryCount = retryCount;
        _subsManager.EventRemoved += SubsManager_EventRemoved;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public void Publish(IntegrationEvent @event)
    {
        if (!_connection.IsConnected)
        {
            _connection.TryConnect();
        }

        var policy = Policy.Handle<BrokerUnreachableException>()
            .Or<SocketException>()
            .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
            {
                _logger.LogWarning(
                    ex,
                    "Could not publish event: {EventId} after {Timeout}s ({ExceptionMessage})",
                    @event.Id,
                    $"{time.TotalSeconds:n1}",
                    ex.Message);
            });

        string eventName = @event.GetType().Name;

        _logger.LogTrace("Creating RabbitMQ channel to publish event: {EventId} ({EventName})", @event.Id, eventName);

        using var channel = _connection.CreateModel();

        _logger.LogTrace("Declaring RabbitMQ exchange to publish event: {EventId}", @event.Id);

        channel.ExchangeDeclare(exchange: BROKER_NAME, type: "direct");

        byte[] body = JsonSerializer.SerializeToUtf8Bytes(@event, @event.GetType(), new JsonSerializerOptions
        {
            WriteIndented = true
        });

        policy.Execute(() =>
        {
            var properties = channel.CreateBasicProperties();

            properties.DeliveryMode = 2; // persistent

            _logger.LogTrace("Publishing event to RabbitMQ: {EventId}", @event.Id);

            channel.BasicPublish(
                exchange: BROKER_NAME,
                routingKey: eventName,
                mandatory: true,
                basicProperties: properties,
                body: body);
        });
    }

    /// <inheritdoc/>
    public void SubscribeDynamic<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler
    {
        _logger.LogInformation("Subscribing to dynamic event {EventName} with {EventHandler}", eventName, typeof(TIntegrationEventHandler).GetGenericTypeName());

        DoInternalSubscription(eventName);

        _subsManager.AddDynamicSubscription<TIntegrationEventHandler>(eventName);

        StartBasicConsume();
    }

    /// <inheritdoc/>
    public void Subscribe<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        string eventName = _subsManager.GetEventKey<TIntegrationEvent>();

        DoInternalSubscription(eventName);

        _logger.LogInformation("Subscribing to event {EventName} with {EventHandler}", eventName, typeof(TIntegrationEventHandler).GetGenericTypeName());

        _subsManager.AddSubscription<TIntegrationEvent, TIntegrationEventHandler>();

        StartBasicConsume();
    }

    /// <inheritdoc/>
    public void Unsubscribe<TIntegrationEvent, TIntegrationEventHandler>()
        where TIntegrationEvent : IntegrationEvent
        where TIntegrationEventHandler : IIntegrationEventHandler<TIntegrationEvent>
    {
        string eventName = _subsManager.GetEventKey<TIntegrationEvent>();

        _logger.LogInformation("Unsubscribing from event {EventName}", eventName);

        _subsManager.RemoveSubscription<TIntegrationEvent, TIntegrationEventHandler>();
    }

    /// <inheritdoc/>
    public void UnsubscribeDynamic<TIntegrationEventHandler>(string eventName)
        where TIntegrationEventHandler : IIntegrationDynamicEventHandler
    {
        _subsManager.RemoveDynamicSubscription<TIntegrationEventHandler>(eventName);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _consumerChannel?.Dispose();

        _subsManager.Clear();
    }

    #endregion Public methods

    #region Private methods

    private void DoInternalSubscription(string eventName)
    {
        bool hasSubscriptions = _subsManager.HasSubscriptionsForEvent(eventName);

        if (!hasSubscriptions)
        {
            if (!_connection.IsConnected)
            {
                _connection.TryConnect();
            }

            _consumerChannel.QueueBind(queue: _queueName, exchange: BROKER_NAME, routingKey: eventName);
        }
    }

    private void StartBasicConsume()
    {
        _logger.LogTrace("Starting RabbitMQ basic consume");

        if (_consumerChannel != null)
        {
            var consumer = new AsyncEventingBasicConsumer(_consumerChannel);

            consumer.Received += Consumer_Received;

            _consumerChannel.BasicConsume(queue: _queueName, autoAck: false, consumer: consumer);
        }
        else
        {
            _logger.LogError("StartBasicConsume can't call on _consumerChannel == null");
        }
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs eventArgs)
    {
        string eventName = eventArgs.RoutingKey;
        string message = Encoding.UTF8.GetString(eventArgs.Body.Span);

        try
        {
            if (message.ToLowerInvariant().Contains("throw-fake-exception"))
            {
                throw new InvalidOperationException($"Fake exception requested: \"{message}\"");
            }

            await ProcessEvent(eventName, message).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "----- ERROR Processing message \"{Message}\"", message);
        }

        // Even on exception we take the message off the queue.
        // in a REAL WORLD app this should be handled with a Dead Letter Exchange (DLX). 
        // For more information see: https://www.rabbitmq.com/dlx.html
        _consumerChannel.BasicAck(eventArgs.DeliveryTag, multiple: false);
    }

    private void SubsManager_EventRemoved(object? sender, string eventName)
    {
        if (!_connection.IsConnected)
        {
            _connection.TryConnect();
        }

        using var channel = _connection.CreateModel();

        channel.QueueUnbind(queue: _queueName,
            exchange: BROKER_NAME,
            routingKey: eventName);

        if (_subsManager.IsEmpty)
        {
            _queueName = string.Empty;
            _consumerChannel.Close();
        }
    }

    private IModel CreateConsumerChannel()
    {
        if (!_connection.IsConnected)
        {
            _connection.TryConnect();
        }

        _logger.LogTrace("Creating RabbitMQ consumer channel");

        var channel = _connection.CreateModel();

        channel.ExchangeDeclare(exchange: BROKER_NAME, type: "direct");

        channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

        channel.CallbackException += (sender, ea) =>
        {
            _logger.LogWarning(ea.Exception, "Recreating RabbitMQ consumer channel");

            _consumerChannel.Dispose();

            _consumerChannel = CreateConsumerChannel();

            StartBasicConsume();
        };

        return channel;
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        _logger.LogTrace("Processing RabbitMQ event: {EventName}", eventName);

        if (_subsManager.HasSubscriptionsForEvent(eventName))
        {
            using var scope = _serviceProvider.CreateScope();

            var subscriptions = _subsManager.GetHandlersForEvent(eventName);

            foreach (var subscription in subscriptions)
            {
                object? handler = scope.ServiceProvider.GetService(subscription.HandlerType);

                if (handler is null)
                {
                    continue;
                }

                if (subscription.IsDynamic)
                {
                    if (handler is not IIntegrationDynamicEventHandler)
                    {
                        continue;
                    }

                    using dynamic eventData = JsonDocument.Parse(message);

                    await Task.Yield();

                    var taskForHandle = ((IIntegrationDynamicEventHandler)handler).Handle(eventData);

                    await taskForHandle.ConfigureAwait(false);
                }
                else
                {
                    var eventType = _subsManager.GetEventTypeByName(eventName);

                    if (eventType is null)
                    {
                        continue;
                    }

                    object? integrationEvent = JsonSerializer.Deserialize(
                        message,
                        eventType,
                        new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    if (integrationEvent is null)
                    {
                        continue;
                    }

                    var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);

                    await Task.Yield();

                    if (concreteType is null)
                    {
                        continue;
                    }

                    var handleMethod = concreteType.GetMethod("Handle");

                    if (handleMethod is null)
                    {
                        continue;
                    }

                    object? result = handleMethod.Invoke(handler, new object[] { integrationEvent });

                    if (result is null)
                    {
                        continue;
                    }

                    if (result is not Task taskForHandle)
                    {
                        continue;
                    }

                    await taskForHandle.ConfigureAwait(false);
                }
            }
        }
        else
        {
            _logger.LogWarning("No subscription for RabbitMQ event: {EventName}", eventName);
        }
    }

    #endregion Private methods
}