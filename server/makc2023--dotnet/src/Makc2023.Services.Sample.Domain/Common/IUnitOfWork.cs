namespace Makc2023.Services.Sample.Domain.Common;

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

    /// <summary>
    /// Сохранить изменения асинхронно.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Признак успешности сохранения.</returns>
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);

    #endregion Methods
}
