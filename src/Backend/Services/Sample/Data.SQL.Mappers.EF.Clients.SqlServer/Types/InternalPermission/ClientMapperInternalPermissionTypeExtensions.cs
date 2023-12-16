// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.InternalPermission;

/// <summary>
/// Расширения типа "Внутреннее разрешение" сопоставителя клиента.
/// </summary>
public static class ClientMapperInternalPermissionTypeExtensions
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperInternalPermissionTypeEntity ToMapperEntity(this InternalPermissionTypeEntity entity)
    {
        ClientMapperInternalPermissionTypeEntity result = new();

        new InternalPermissionTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static InternalPermissionTypeEntity ToEntity(this ClientMapperInternalPermissionTypeEntity mapperEntity)
    {
        InternalPermissionTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
