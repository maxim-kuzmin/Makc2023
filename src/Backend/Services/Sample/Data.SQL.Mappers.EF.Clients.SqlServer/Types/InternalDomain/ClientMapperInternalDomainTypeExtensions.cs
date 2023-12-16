// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.InternalDomain;

/// <summary>
/// Расширения сущности "Внутренний домен" сопоставителя клиента.
/// </summary>
public static class ClientMapperInternalDomainTypeExtensions
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperInternalDomainTypeEntity ToMapperEntity(this InternalDomainTypeEntity entity)
    {
        ClientMapperInternalDomainTypeEntity result = new();

        new InternalDomainTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static InternalDomainTypeEntity ToEntity(this ClientMapperInternalDomainTypeEntity mapperEntity)
    {
        InternalDomainTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
