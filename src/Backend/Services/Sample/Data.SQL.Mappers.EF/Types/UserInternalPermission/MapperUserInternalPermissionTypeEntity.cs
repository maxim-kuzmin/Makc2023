// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.UserInternalPermission;

/// <summary>
/// Сущность типа "Внутреннее разрешение пользователя" сопоставителя.
/// </summary>
public class MapperUserInternalPermissionTypeEntity : UserInternalPermissionTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Пользователь".
    /// </summary>
    public MapperUserTypeEntity? User { get; set; }

    /// <summary>
    /// Экземпляр сущности "Внутреннее разрешение".
    /// </summary>
    public MapperInternalPermissionTypeEntity? InternalPermission { get; set; }

    #endregion Navigation properties
}
