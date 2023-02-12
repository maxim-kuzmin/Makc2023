// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyOneToMany;

/// <summary>
/// Сущность типа "Фиктивное отношение один ко многим" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyOneToManyTypeEntity : DummyOneToManyTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Фиктивное главное".
    /// </summary>
    public List<ClientMapperDummyMainTypeEntity> DummyMainList { get; } = new();

    #endregion Navigation properties
}
