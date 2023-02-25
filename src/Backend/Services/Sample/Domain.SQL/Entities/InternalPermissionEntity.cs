// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Entities;

/// <summary>
/// Сущность "Внутреннее разрешение".
/// </summary>
public class InternalPermissionEntity : Entity<long>
{
    #region Properties

    /// <summary>
    /// Данные.
    /// </summary>
    public InternalPermissionTypeEntity Data { get; }

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data">Данные.</param>
    public InternalPermissionEntity(InternalPermissionTypeEntity? data = null)
    {
        Data = data ?? new InternalPermissionTypeEntity();
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Data.Id;

    #endregion Protected methods
}