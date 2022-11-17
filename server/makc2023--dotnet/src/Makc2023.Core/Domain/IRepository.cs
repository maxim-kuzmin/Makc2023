namespace Makc2023.Core.Domain;

/// <summary>
/// Интерфейс репозитория.
/// </summary>
public interface IRepository<T> where T : IAggregateRoot
{
    #region Properties

    /// <summary>
    /// Единица работы.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

    #endregion Properties
}
