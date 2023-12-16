// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyTreeLink;

/// <summary>
/// Расширения сущности "Связь фиктивного дерева" сопоставителя клиента.
/// </summary>
public static class ClientMapperDummyTreeLinkTypeExtensions
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperDummyTreeLinkTypeEntity ToMapperEntity(this DummyTreeLinkTypeEntity entity)
    {
        ClientMapperDummyTreeLinkTypeEntity result = new();

        new DummyTreeLinkTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static DummyTreeLinkTypeEntity ToEntity(this ClientMapperDummyTreeLinkTypeEntity mapperEntity)
    {
        DummyTreeLinkTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
