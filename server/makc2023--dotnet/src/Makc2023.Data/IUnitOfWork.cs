// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data;

/// <summary>
/// Интерфейс единицы работы.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    #region Methods

    /// <summary>
    /// Сохранить изменения асинхронно.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Количество сохранённых записей.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion Methods
}
