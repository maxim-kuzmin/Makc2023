// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.DummyManyToMany;

/// <summary>
/// Сущность типа "Фиктивное отношение многие ко многим" сопоставителя.
/// </summary>
public class MapperDummyManyToManyTypeEntity : DummyManyToManyTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public List<MapperDummyMainDummyManyToManyTypeEntity> DummyMainDummyManyToManyList { get; } = new();

    #endregion Navigation properties
}
