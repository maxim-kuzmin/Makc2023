// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyTree;

/// <summary>
/// Расширение сущности "Фиктивное дерево" сопоставителя.
/// </summary>
public static class MapperDummyTreeTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя.</returns>
    public static MapperDummyTreeTypeEntity ToMapperEntity(this DummyTreeTypeEntity entity)
    {
        MapperDummyTreeTypeEntity result = new();

        new DummyTreeTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя.</param>
    /// <returns>Сущность.</returns>
    public static DummyTreeTypeEntity ToEntity(this MapperDummyTreeTypeEntity mapperEntity)
    {
        DummyTreeTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
