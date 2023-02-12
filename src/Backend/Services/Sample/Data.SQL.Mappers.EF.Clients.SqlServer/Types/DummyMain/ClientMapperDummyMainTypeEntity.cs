// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyMain;

/// <summary>
/// Сущность типа "Фиктивное главное" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyMainTypeEntity : DummyMainTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public List<ClientMapperDummyMainDummyManyToManyTypeEntity> DummyMainDummyManyToManyList { get; } = new();

    /// <summary>
    /// Список экземпляров сущности "Фиктивное отношение многие к одному".
    /// </summary>
    public List<ClientMapperDummyManyToOneTypeEntity> DummyManyToOneList { get; } = new();

    /// <summary>
    /// Экземпляр сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public ClientMapperDummyOneToManyTypeEntity? DummyOneToMany { get; set; }

    #endregion Navigation properties
}
