// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyMain;

/// <summary>
/// Сущность типа "Фиктивное главное" сопоставителя.
/// </summary>
public class MapperDummyMainTypeEntity : DummyMainTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public List<MapperDummyMainDummyManyToManyTypeEntity> DummyMainDummyManyToManyList { get; } = new();

    /// <summary>
    /// Список экземпляров сущности "Фиктивное отношение многие к одному".
    /// </summary>
    public List<MapperDummyManyToOneTypeEntity> DummyManyToOneList { get; } = new();

    /// <summary>
    /// Экземпляр сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public MapperDummyOneToManyTypeEntity? DummyOneToMany { get; set; }

    #endregion Navigation properties
}
