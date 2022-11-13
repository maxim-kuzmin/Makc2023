namespace Makc2023.Services.Sample.Domain.Common;

/// <summary>
/// Интерфейс репозитория.
/// </summary>
public interface IRepository
{
    #region Properties

    /// <summary>
    /// Единица работы.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

    #endregion Properties
}
