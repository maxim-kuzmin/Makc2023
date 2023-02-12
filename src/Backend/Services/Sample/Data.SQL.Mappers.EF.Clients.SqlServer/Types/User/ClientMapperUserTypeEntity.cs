// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.User;

/// <summary>
/// Сущность типа "Пользователь" сопоставителя клиента.
/// </summary>
public class ClientMapperUserTypeEntity : UserTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Внутреннее разрешение пользователя".
    /// </summary>
    public List<ClientMapperUserInternalPermissionTypeEntity> UserInternalPermissionList { get; } = new();

    #endregion Navigation properties
}
