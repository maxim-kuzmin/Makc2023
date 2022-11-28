// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain;

/// <summary>
/// Интерфейс сервиса домена.
/// </summary>
public interface IDomainService
{
    #region Methods

    /// <summary>
    /// Получить элемент.
    /// </summary>
    /// <param name="input">Входные данные.</param>
    /// <returns>Задача на выполнение операции с выходными данными.</returns>
    Task<DomainItemGetOperationOutput?> GetItem(DomainItemGetOperationInput input);

    /// <summary>
    /// Получить список.
    /// </summary>
    /// <param name="input">Входные данные.</param>
    /// <returns>Задача на выполнение операции с выходными данными.</returns>
    Task<DomainListGetOperationOutput> GetList(DomainListGetOperationInput input);

    #endregion Methods
}
