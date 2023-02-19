// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Entities;

/// <summary>
/// Сущность "Фиктивное отношение многие к одному".
/// </summary>
public class DummyManyToOneEntity : Entity<long>
{
    #region Properties

    /// <summary>
    /// Данные.
    /// </summary>
    public DummyManyToOneTypeEntity Data { get; init; }

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data">Данные.</param>
    public DummyManyToOneEntity(DummyManyToOneTypeEntity? data = null)
    {
        Data = data ?? new DummyManyToOneTypeEntity();
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Data.Id;

    #endregion Protected methods
}