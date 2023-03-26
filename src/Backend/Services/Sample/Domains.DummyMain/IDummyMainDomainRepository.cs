// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain;

/// <summary>
/// Интерфейс репозитория домена "Фиктивное главное".
/// </summary>
public interface IDummyMainDomainRepository : IRepository<DummyMainDomainEntity>
{
    #region Methods

    /// <summary>
    /// Получить элемент.
    /// </summary>
    /// <param name="input">Входные данные.</param>
    /// <returns>Задача на получение элемента.</returns>
    Task<DummyMainDomainItemGetOperationOutput> GetItem(DummyMainDomainItemGetOperationInput input);

    /// <summary>
    /// Получить список.
    /// </summary>
    /// <param name="input">Входные данные.</param>
    /// <returns>Задача на получение списка.</returns>
    Task<DummyMainDomainListGetOperationOutput> GetList(DummyMainDomainListGetOperationInput input);

    #endregion Methods
}
