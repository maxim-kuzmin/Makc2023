// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Domain;

/// <summary>
/// Интерфейс сущности.
/// </summary>
public interface IEntity
{
    #region Methods

    /// <summary>
    /// Очистить события.
    /// </summary>
    void ClearEvents();

    /// <summary>
    /// Получить события.
    /// </summary>
    IReadOnlyCollection<INotification>? GetEvents();

    #endregion Methods
}
