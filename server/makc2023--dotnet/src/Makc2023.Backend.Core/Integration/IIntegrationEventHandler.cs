// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Core.Integration;

/// <summary>
/// Обработчик события интеграции.
/// </summary>
/// <typeparam name="TIntegrationEvent">Тип события интеграции.</typeparam>
public interface IIntegrationEventHandler<in TIntegrationEvent>
    where TIntegrationEvent : IntegrationEvent
{
    #region Methods

    /// <summary>
    /// Обработать.
    /// </summary>
    /// <param name="event">Событие.</param>
    /// <returns>Задача на обработку.</returns>
    Task Handle(TIntegrationEvent @event);

    #endregion Methods
}

