// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Integration;

/// <summary>
/// Интерфейс сервиса интеграции.
/// </summary>
public interface IIntegrationService
{
    #region Methods

    /// <summary>
    /// Опубликовать события.
    /// </summary>
    /// <param name="transactionId">Идентификатор транзакции.</param>
    /// <returns>Задача на публикацию событий.</returns>
    Task PublishEvents(Guid transactionId);

    #endregion Methods
}
