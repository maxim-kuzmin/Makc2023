// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyMain;

/// <summary>
/// Расширение типа "Фиктивное главное" сопоставителя клиента.
/// </summary>
public static class ClientMapperDummyMainTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperDummyMainTypeEntity ToMapperEntity(this DummyMainTypeEntity entity)
    {
        ClientMapperDummyMainTypeEntity result = new();

        new DummyMainTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static DummyMainTypeEntity ToEntity(this ClientMapperDummyMainTypeEntity mapperEntity)
    {
        DummyMainTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
