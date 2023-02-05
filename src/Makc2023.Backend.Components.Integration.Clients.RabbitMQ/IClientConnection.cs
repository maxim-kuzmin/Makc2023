namespace Makc2023.Backend.Components.Integration.Clients.RabbitMQ;

/// <summary>
/// Интерфейс подключения клиента.
/// </summary>
public interface IClientConnection : IDisposable
{
    #region Properties

    /// <summary>
    /// Признак того, что клиент подключен.
    /// </summary>
    bool IsConnected { get; }

    #endregion Properties

    #region Methods

    /// <summary>
    /// Попробовать подключиться.
    /// </summary>
    /// <returns>Признак того, что клиент подключен.</returns>
    bool TryConnect();

    /// <summary>
    /// Создать модель.
    /// </summary>
    /// <returns>Модель.</returns>
    IModel CreateModel();

    #endregion Methods
}
