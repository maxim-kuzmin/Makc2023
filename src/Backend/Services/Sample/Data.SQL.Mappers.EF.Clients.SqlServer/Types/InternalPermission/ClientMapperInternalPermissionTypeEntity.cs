// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.InternalPermission;

/// <summary>
/// Сущность типа "Внутреннее разрешение" сопоставителя клиента.
/// </summary>
public class ClientMapperInternalPermissionTypeEntity : InternalPermissionTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Внутренний домен".
    /// </summary>
    public ClientMapperInternalDomainTypeEntity? InternalDomain { get; set; }

    /// <summary>
    /// Список экземпляров сущности "Внутреннее разрешение пользователя".
    /// </summary>
    public List<ClientMapperUserInternalPermissionTypeEntity> UserInternalPermissionList { get; } = new();    

    #endregion Navigation properties
}