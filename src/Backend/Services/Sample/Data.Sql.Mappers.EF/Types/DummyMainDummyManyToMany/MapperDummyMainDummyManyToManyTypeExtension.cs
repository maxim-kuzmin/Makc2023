// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Types.DummyMainDummyManyToMany;

/// <summary>
/// Расширение типа "Фиктивное отношение многие ко многим фиктивного главного" сопоставителя.
/// </summary>
public static class MapperDummyMainDummyManyToManyTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя.</returns>
    public static MapperDummyMainDummyManyToManyTypeEntity ToMapperEntity(this DummyMainDummyManyToManyTypeEntity entity)
    {
        MapperDummyMainDummyManyToManyTypeEntity result = new();

        new DummyMainDummyManyToManyTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя.</param>
    /// <returns>Сущность.</returns>
    public static DummyMainDummyManyToManyTypeEntity ToEntity(this MapperDummyMainDummyManyToManyTypeEntity mapperEntity)
    {
        DummyMainDummyManyToManyTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
