﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.UserInternalPermission;

/// <summary>
/// Сущность типа "Внутреннее разрешение пользователя" сопоставителя клиента.
/// </summary>
public class ClientMapperUserInternalPermissionTypeEntity : UserInternalPermissionTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Пользователь".
    /// </summary>
    public ClientMapperUserTypeEntity? User { get; set; }

    /// <summary>
    /// Экземпляр сущности "Внутреннее разрешение".
    /// </summary>
    public ClientMapperInternalPermissionTypeEntity? InternalPermission { get; set; }

    #endregion Navigation properties
}
