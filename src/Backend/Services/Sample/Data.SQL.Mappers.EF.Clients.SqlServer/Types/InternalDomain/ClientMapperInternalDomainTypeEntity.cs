// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.InternalDomain;

/// <summary>
/// Сущность типа "Внутренний домен" сопоставителя клиента.
/// </summary>
public class ClientMapperInternalDomainTypeEntity : InternalDomainTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Внутреннее разрешение".
    /// </summary>
    public List<ClientMapperInternalPermissionTypeEntity> InternalPermissionList { get; } = new();

    #endregion Navigation properties
}
