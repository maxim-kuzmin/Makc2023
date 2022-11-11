namespace Makc2023.Services.Sample.Domain.SeedWork;

/// <summary>
/// Интерфейс репозитория.
/// </summary>
/// <typeparam name="T">Тип корня агрегата.</typeparam>
public interface IRepository<T> where T : IAggregateRoot
{
    #region Properties

    /// <summary>
    /// Единица работы.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

    #endregion Properties
}
