// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyOneToMany;

/// <summary>
/// Расширение сущности "Фиктивное отношение один ко многим" сопоставителя клиента.
/// </summary>
public static class ClientMapperDummyOneToManyTypeExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать в сущность сопоставителя клиента.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сущность сопоставителя клиента.</returns>
    public static ClientMapperDummyOneToManyTypeEntity ToMapperEntity(this DummyOneToManyTypeEntity entity)
    {
        ClientMapperDummyOneToManyTypeEntity result = new();

        new DummyOneToManyTypeLoader(result).Load(entity);

        return result;
    }

    /// <summary>
    /// Преобразовать в сущность.
    /// </summary>
    /// <param name="mapperEntity">Сущность сопоставителя клиента.</param>
    /// <returns>Сущность.</returns>
    public static DummyOneToManyTypeEntity ToEntity(this ClientMapperDummyOneToManyTypeEntity mapperEntity)
    {
        DummyOneToManyTypeLoader loader = new();

        loader.Load(mapperEntity);

        return loader.Target;
    }

    #endregion Public methods
}
