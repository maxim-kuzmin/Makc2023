// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Core.Integration;

/// <summary>
/// Обработчик динамического события интеграции.
/// </summary>
public interface IIntegrationDynamicEventHandler
{
    #region Methods

    /// <summary>
    /// Обработать.
    /// </summary>
    /// <param name="eventData">Данные события.</param>
    /// <returns>Задача на обработку.</returns>
    Task Handle(dynamic eventData);

    #endregion Methods
}

