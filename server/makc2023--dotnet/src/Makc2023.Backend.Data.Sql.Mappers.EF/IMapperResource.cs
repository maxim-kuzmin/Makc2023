// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Data.Sql.Mappers.EF;

/// <summary>
/// Интерфейс ресурса сопоставителя.
/// </summary>
public interface IMapperResource
{
    #region Methods

    /// <summary>
    /// Получить сообщение об ошибке для внешней транзакции.
    /// </summary>
    /// <param name="transactionId">Идентификатор транзакции.</param>
    /// <returns>Сообщение об ошибке.</returns>
    string GetErrorMessageForExternalTransaction(Guid transactionId);

    #endregion Methods
}