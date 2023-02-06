// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Пользователь".
/// </summary>
public class UserEntity : Entity<long>
{
    #region Fields

    private readonly List<InternalPermissionEntity> _internalPermissionList = new();

    #endregion Fields

    #region Properties

    /// <summary>
    /// Данные.
    /// </summary>
    public UserTypeEntity Data { get; init; }

    #endregion Properties    

    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Внутреннее разрешение".
    /// </summary>
    public IReadOnlyCollection<InternalPermissionEntity> InternalPermissionList => _internalPermissionList;

    #endregion Navigation properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data">Данные.</param>
    public UserEntity(UserTypeEntity data)
    {
        Data = data;
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Data.Id;

    #endregion Protected methods
}