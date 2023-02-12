// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyMainDummyManyToMany;

/// <summary>
/// Сущность типа "Фиктивное отношение многие ко многим фиктивного главного" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyMainDummyManyToManyTypeEntity : DummyMainDummyManyToManyTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Фиктивное главное".
    /// </summary>
    public ClientMapperDummyMainTypeEntity? DummyMain { get; set; }

    /// <summary>
    /// Экземпляр сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public ClientMapperDummyManyToManyTypeEntity? DummyManyToMany { get; set; }

    #endregion Navigation properties
}
