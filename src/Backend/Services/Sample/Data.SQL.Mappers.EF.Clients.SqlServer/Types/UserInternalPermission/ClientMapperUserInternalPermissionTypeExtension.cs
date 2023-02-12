// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.UserInternalPermission;

/// <summary>
/// Расширение типа "Внутреннее разрешение пользователя" сопоставителя клиента.
/// </summary>
public static class ClientMapperUserInternalPermissionTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperUserInternalPermissionTypeEntity ToMapperEntity(this UserInternalPermissionTypeEntity entity)
    {
        ClientMapperUserInternalPermissionTypeEntity result = new();

        new UserInternalPermissionTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static UserInternalPermissionTypeEntity ToEntity(this ClientMapperUserInternalPermissionTypeEntity mapperEntity)
    {
        UserInternalPermissionTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
