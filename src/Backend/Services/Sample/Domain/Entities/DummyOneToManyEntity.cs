// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Фиктивное отношение один ко многим".
/// </summary>
public class DummyOneToManyEntity : Entity<long>, IAggregateRoot
{
    #region Properties

    /// <summary>
    /// Данные.
    /// </summary>
    public DummyOneToManyTypeEntity Data { get; init; }

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data">Данные.</param>
    public DummyOneToManyEntity(DummyOneToManyTypeEntity data)
    {
        Data = data;
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Data.Id;

    #endregion Protected methods
}
