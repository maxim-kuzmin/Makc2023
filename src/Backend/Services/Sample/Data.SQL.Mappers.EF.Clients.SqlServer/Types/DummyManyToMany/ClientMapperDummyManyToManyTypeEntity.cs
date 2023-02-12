// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyManyToMany;

/// <summary>
/// Сущность типа "Фиктивное отношение многие ко многим" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyManyToManyTypeEntity : DummyManyToManyTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public List<ClientMapperDummyMainDummyManyToManyTypeEntity> DummyMainDummyManyToManyList { get; } = new();

    #endregion Navigation properties
}
