// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyMainDummyManyToMany;

/// <summary>
/// Расширения типа "Фиктивное отношение многие ко многим фиктивного главного" сопоставителя клиента.
/// </summary>
public static class ClientMapperDummyMainDummyManyToManyTypeExtensions
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperDummyMainDummyManyToManyTypeEntity ToMapperEntity(this DummyMainDummyManyToManyTypeEntity entity)
    {
        ClientMapperDummyMainDummyManyToManyTypeEntity result = new();

        new DummyMainDummyManyToManyTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static DummyMainDummyManyToManyTypeEntity ToEntity(this ClientMapperDummyMainDummyManyToManyTypeEntity mapperEntity)
    {
        DummyMainDummyManyToManyTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
