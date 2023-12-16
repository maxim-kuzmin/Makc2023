// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyTree;

/// <summary>
/// Расширения сущности "Фиктивное дерево" сопоставителя клиента.
/// </summary>
public static class ClientMapperDummyTreeTypeExtensions
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperDummyTreeTypeEntity ToMapperEntity(this DummyTreeTypeEntity entity)
    {
        ClientMapperDummyTreeTypeEntity result = new();

        new DummyTreeTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static DummyTreeTypeEntity ToEntity(this ClientMapperDummyTreeTypeEntity mapperEntity)
    {
        DummyTreeTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
