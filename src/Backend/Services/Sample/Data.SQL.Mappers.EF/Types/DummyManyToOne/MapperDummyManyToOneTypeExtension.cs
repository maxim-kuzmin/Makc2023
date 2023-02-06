// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyManyToOne;

/// <summary>
/// Расширение типа "Фиктивное главное" сопоставителя.
/// </summary>
public static class MapperDummyManyToOneTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя.</returns>
    public static MapperDummyManyToOneTypeEntity ToMapperEntity(this DummyManyToOneTypeEntity entity)
    {
        MapperDummyManyToOneTypeEntity result = new();

        new DummyManyToOneTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя.</param>
    /// <returns>Сущность.</returns>
    public static DummyManyToOneTypeEntity ToEntity(this MapperDummyManyToOneTypeEntity mapperEntity)
    {
        DummyManyToOneTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
