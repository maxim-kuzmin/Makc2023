// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Domain;

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
