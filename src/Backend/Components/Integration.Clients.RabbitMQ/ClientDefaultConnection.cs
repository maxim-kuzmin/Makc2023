// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Components.Integration.Clients.RabbitMQ;

/// <summary>
/// Подключение по умолчанию клиента.
/// </summary>
public sealed class ClientDefaultConnection : IClientConnection
{
    #region Fields

    private readonly IConnectionFactory _connectionFactory;
    private readonly ILogger<ClientDefaultConnection> _logger;
    private readonly int _retryCount;
    private IConnection? _connection;
    private readonly object _syncRoot = new();

    /// <summary>
    /// Признак того, что подключение закрыто.
    /// </summary>
    public bool Disposed;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Признак того, что подключение установлено.
    /// </summary>
    public bool IsConnected => _connection is { IsOpen: true } && !Disposed;

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="connectionFactory">Фабрика подключений.</param>
    /// <param name="logger">Регистратор.</param>
    /// <param name="retryCount">Количество повторений попыток создания подключения в случае неудачи.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public ClientDefaultConnection(
        IConnectionFactory connectionFactory,
        ILogger<ClientDefaultConnection> logger,
        int retryCount = 5)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _retryCount = retryCount;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public IModel CreateModel()
    {
        if (!IsConnected || _connection is null)
        {
            throw new InvalidOperationException("No RabbitMQ connections are available to perform this action");
        }

        return _connection.CreateModel();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (Disposed)
        {
            return;
        }

        Disposed = true;

        try
        {
            if (_connection is not null)
            {
                _connection.ConnectionShutdown -= OnConnectionShutdown;
                _connection.CallbackException -= OnCallbackException;
                _connection.ConnectionBlocked -= OnConnectionBlocked;
                _connection.Dispose();
            }
        }
        catch (IOException ex)
        {
            _logger.LogCritical(ex, "Couldn't be connected to RabbitMQ while dispose");
        }
    }

    /// <inheritdoc/>
    public bool TryConnect()
    {
        _logger.LogInformation("RabbitMQ Client is trying to connect");

        lock (_syncRoot)
        {
            var policy = Policy.Handle<SocketException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                {
                    _logger.LogWarning(
                        ex,
                        "RabbitMQ Client could not connect after {TimeOut}s ({ExceptionMessage})",
                        $"{time.TotalSeconds:n1}",
                        ex.Message);
                }
            );

            policy.Execute(() =>
            {
                _connection = _connectionFactory.CreateConnection();
            });

            if (IsConnected && _connection is not null)
            {
                _connection.ConnectionShutdown += OnConnectionShutdown;
                _connection.CallbackException += OnCallbackException;
                _connection.ConnectionBlocked += OnConnectionBlocked;

                _logger.LogInformation("RabbitMQ Client acquired a persistent connection to '{HostName}' and is subscribed to failure events", _connection.Endpoint.HostName);

                return true;
            }
            else
            {
                _logger.LogCritical("FATAL ERROR: RabbitMQ connections could not be created and opened");

                return false;
            }
        }
    }

    #endregion Public methods

    #region Private methods

    private void OnConnectionBlocked(object? sender, ConnectionBlockedEventArgs e)
    {
        if (Disposed)
        {
            return;
        }

        _logger.LogWarning("A RabbitMQ connection is shutdown. Trying to re-connect...");

        TryConnect();
    }

    private void OnCallbackException(object? sender, CallbackExceptionEventArgs e)
    {
        if (Disposed)
        {
            return;
        }

        _logger.LogWarning("A RabbitMQ connection throw exception. Trying to re-connect...");

        TryConnect();
    }

    private void OnConnectionShutdown(object? sender, ShutdownEventArgs reason)
    {
        if (Disposed)
        {
            return;
        }

        _logger.LogWarning("A RabbitMQ connection is on shutdown. Trying to re-connect...");

        TryConnect();
    }

    #endregion Private methods
}
