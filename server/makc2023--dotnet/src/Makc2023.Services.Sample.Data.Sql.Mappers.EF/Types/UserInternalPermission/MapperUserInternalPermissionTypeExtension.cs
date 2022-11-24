// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.UserInternalPermission;

/// <summary>
/// Расширение типа "Внутреннее разрешение пользователя" сопоставителя.
/// </summary>
public static class MapperUserInternalPermissionTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя.</returns>
    public static MapperUserInternalPermissionTypeEntity ToMapperEntity(this UserInternalPermissionTypeEntity entity)
    {
        MapperUserInternalPermissionTypeEntity result = new();

        new UserInternalPermissionTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя.</param>
    /// <returns>Сущность.</returns>
    public static UserInternalPermissionTypeEntity ToEntity(this MapperUserInternalPermissionTypeEntity mapperEntity)
    {
        UserInternalPermissionTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
