// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.DummyTreeLink;

/// <summary>
/// Расширение сущности "Связь фиктивного дерева" сопоставителя.
/// </summary>
public static class MapperDummyTreeLinkTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя.</returns>
    public static MapperDummyTreeLinkTypeEntity ToMapperEntity(this DummyTreeLinkTypeEntity entity)
    {
        MapperDummyTreeLinkTypeEntity result = new();

        new DummyTreeLinkTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя.</param>
    /// <returns>Сущность.</returns>
    public static DummyTreeLinkTypeEntity ToEntity(this MapperDummyTreeLinkTypeEntity mapperEntity)
    {
        DummyTreeLinkTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
