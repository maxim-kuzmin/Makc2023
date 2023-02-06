// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Types.DummyMainDummyManyToMany;

/// <summary>
/// Сущность типа "Фиктивное отношение многие ко многим фиктивного главного" сопоставителя.
/// </summary>
public class MapperDummyMainDummyManyToManyTypeEntity : DummyMainDummyManyToManyTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Фиктивное главное".
    /// </summary>
    public MapperDummyMainTypeEntity? DummyMain { get; set; }

    /// <summary>
    /// Экземпляр сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public MapperDummyManyToManyTypeEntity? DummyManyToMany { get; set; }

    #endregion Navigation properties
}
