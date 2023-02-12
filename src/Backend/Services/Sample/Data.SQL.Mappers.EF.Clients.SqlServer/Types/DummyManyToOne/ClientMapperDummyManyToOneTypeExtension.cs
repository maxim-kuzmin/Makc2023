// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyManyToOne;

/// <summary>
/// Расширение типа "Фиктивное главное" сопоставителя клиента.
/// </summary>
public static class ClientMapperDummyManyToOneTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperDummyManyToOneTypeEntity ToMapperEntity(this DummyManyToOneTypeEntity entity)
    {
        ClientMapperDummyManyToOneTypeEntity result = new();

        new DummyManyToOneTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static DummyManyToOneTypeEntity ToEntity(this ClientMapperDummyManyToOneTypeEntity mapperEntity)
    {
        DummyManyToOneTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
