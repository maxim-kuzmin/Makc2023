// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Core.Integration;

/// <summary>
/// Интерфейс сервиса интеграции.
/// </summary>
public interface IIntegrationService
{
    #region Methods

    /// <summary>
    /// Опубликовать события через шину событий асинхронно.
    /// </summary>
    /// <param name="transactionId">Идентификатор транзакции.</param>
    /// <returns>Задача на опубликование событий.</returns>
    Task PublishEventsThroughEventBusAsync(Guid transactionId);

    /// <summary>
    /// Добавить и сохранить событие асинхронно.
    /// </summary>
    /// <param name="evt">Событие.</param>
    /// <returns>Задача на добавление и сохранение.</returns>
    Task AddAndSaveEventAsync(IntegrationEvent evt);

    #endregion Methods
}
