// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.UserInternalPermission;

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.InternalPermission;

/// <summary>
/// Сущность типа "Внутреннее разрешение" сопоставителя.
/// </summary>
public class MapperInternalPermissionTypeEntity : InternalPermissionTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Внутренний домен".
    /// </summary>
    public MapperInternalDomainTypeEntity? InternalDomain { get; set; }

    /// <summary>
    /// Список экземпляров сущности "Внутреннее разрешение пользователя".
    /// </summary>
    public List<MapperUserInternalPermissionTypeEntity> UserInternalPermissionList { get; } = new();    

    #endregion Navigation properties
}