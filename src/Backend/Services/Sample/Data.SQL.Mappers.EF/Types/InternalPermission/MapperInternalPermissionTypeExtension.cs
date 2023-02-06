// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.InternalPermission;

/// <summary>
/// Расширение типа "Внутреннее разрешение" сопоставителя.
/// </summary>
public static class MapperInternalPermissionTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя.</returns>
    public static MapperInternalPermissionTypeEntity ToMapperEntity(this InternalPermissionTypeEntity entity)
    {
        MapperInternalPermissionTypeEntity result = new();

        new InternalPermissionTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя.</param>
    /// <returns>Сущность.</returns>
    public static InternalPermissionTypeEntity ToEntity(this MapperInternalPermissionTypeEntity mapperEntity)
    {
        InternalPermissionTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
