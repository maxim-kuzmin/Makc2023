// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyManyToMany;

/// <summary>
/// Расширение типа "Фиктивное отношение многие ко многим" сопоставителя клиента.
/// </summary>
public static class ClientMapperDummyManyToManyTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperDummyManyToManyTypeEntity ToMapperEntity(this DummyManyToManyTypeEntity entity)
    {
        ClientMapperDummyManyToManyTypeEntity result = new();

        new DummyManyToManyTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static DummyManyToManyTypeEntity ToEntity(this ClientMapperDummyManyToManyTypeEntity mapperEntity)
    {
        DummyManyToManyTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
