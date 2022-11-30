// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Data.Sql.Mappers.EF.Db;

/// <summary>
/// Интерфейс менеджера базы данных сопоставителя.
/// </summary>
public interface IMapperDbManager
{
    #region Properties

    /// <summary>
    /// Содержит транзакцию.
    /// </summary>
    bool HasTransaction { get; }

    /// <summary>
    /// Признак того, что менеджер базы данных использован.
    /// </summary>
    bool IsUsed { get; }

    #endregion Properties

    #region Methods

    /// <summary>
    /// Создать стратегию выполнения.
    /// </summary>
    /// <returns>Стратегия.</returns>
    IExecutionStrategy CreateExecutionStrategy();

    /// <summary>
    /// Начать транзакцию асинхронно.
    /// Если возвращается нуль, транзакция уже начата и нужно использовать текущую.
    /// </summary>
    /// <returns>Задача с транзакцией или нулём.</returns>
    Task<IDbContextTransaction?> BeginTransactionAsync();

    /// <summary>
    /// Зафиксировать транзакцию асинхронно.
    /// </summary>
    /// <param name="transaction">Транзакция.</param>
    /// <returns>Задача.</returns>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    /// <exception cref="LocalizedException">
    /// Возникает, если транзакция является внешней.
    /// </exception>
    Task CommitTransactionAsync(IDbContextTransaction transaction);

    #endregion Methods
}
