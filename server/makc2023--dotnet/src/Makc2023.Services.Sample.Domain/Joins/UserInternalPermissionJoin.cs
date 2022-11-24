// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domain.Joins;

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
    public long UserId { get; private set; }

    /// <summary>
    /// Идентификатор экземпляра сущности "Внутреннее разрешение".
    /// </summary>
    public long InternalPermissionId { get; private set; }

    #endregion Properties

    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Пользователь".
    /// </summary>
    public UserEntity? User { get; set; }

    /// <summary>
    /// Экземпляр сущности "Внутреннее разрешение".
    /// </summary>
    public InternalPermissionEntity? InternalPermission { get; set; }

    #endregion Navigation properties
}
