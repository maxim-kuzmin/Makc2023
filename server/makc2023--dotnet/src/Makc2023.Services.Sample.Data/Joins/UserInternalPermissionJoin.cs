// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Joins;

/// <summary>
/// Соединение "Внутреннее разрешение пользователя".
/// 
/// Связывает экземпляр сущности "Пользователь" с экземпляром сущности "Внутреннее разрешение".
///
/// Используется для разграничения прав доступа в доменах сервиса.
/// </summary>
public class UserInternalPermissionJoin
{
    #region Properties

    /// <summary>
    /// Идентификатор экземпляра сущности "Пользователь".
    /// </summary>
    public int UserId { get; private set; }

    /// <summary>
    /// Идентификатор экземпляра сущности "Внутреннее разрешение".
    /// </summary>
    public int InternalPermissionId { get; private set; }

    #endregion Properties

    #region Navigation properties

    /// <summary>
    /// Сущность "Пользователь".
    /// </summary>
    public UserEntity? User { get; set; }

    /// <summary>
    /// Сущность "Внутреннее разрешение".
    /// </summary>
    public InternalPermissionEntity? InternalPermission { get; set; }

    #endregion Navigation properties
}
