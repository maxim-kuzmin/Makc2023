// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Repositories;

/// <summary>
/// Интерфейс репозитория "Фиктивное главное".
/// </summary>
public interface IDummyMainRepository : IRepository<DummyMainEntity>
{
    #region Methods

    /// <summary>
    /// Получить элемент.
    /// </summary>
    /// <param name="input">Входные данные.</param>
    /// <returns>Задача на получение элемента.</returns>
    Task<DummyMainItemGetOperationOutput> GetItem(DummyMainItemGetOperationInput input);

    /// <summary>
    /// Получить список.
    /// </summary>
    /// <param name="input">Входные данные.</param>
    /// <returns>Задача на получение списка.</returns>
    Task<DummyMainListGetOperationOutput> GetList(DummyMainListGetOperationInput input);

    #endregion Methods
}
