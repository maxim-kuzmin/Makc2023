// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.InternalDomain;

/// <summary>
/// Расширение сущности "Внутренний домен" сопоставителя.
/// </summary>
public static class MapperInternalDomainTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя.</returns>
    public static MapperInternalDomainTypeEntity ToMapperEntity(this InternalDomainTypeEntity entity)
    {
        MapperInternalDomainTypeEntity result = new();

        new InternalDomainTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя.</param>
    /// <returns>Сущность.</returns>
    public static InternalDomainTypeEntity ToEntity(this MapperInternalDomainTypeEntity mapperEntity)
    {
        InternalDomainTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
