// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.UserInternalPermission;

/// <summary>
/// Сущность типа "Внутреннее разрешение пользователя".
/// 
/// Связывает экземпляр сущности "Пользователь" с экземпляром сущности "Внутреннее разрешение".
///
/// Используется для разграничения прав доступа в доменах сервиса.
/// </summary>
public class UserInternalPermissionTypeEntity
{
    #region Properties

    /// <summary>
    /// Идентификатор экземпляра сущности "Пользователь".
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Идентификатор экземпляра сущности "Внутреннее разрешение".
    /// </summary>
    public long InternalPermissionId { get; set; }

    #endregion Properties
}
