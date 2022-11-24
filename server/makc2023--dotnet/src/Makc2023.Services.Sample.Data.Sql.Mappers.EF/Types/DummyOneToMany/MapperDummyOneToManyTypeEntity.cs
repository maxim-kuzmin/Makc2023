// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.DummyOneToMany;

/// <summary>
/// Сущность типа "Фиктивное отношение один ко многим" сопоставителя.
/// </summary>
public class MapperDummyOneToManyTypeEntity : DummyOneToManyTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Фиктивное главное".
    /// </summary>
    public List<MapperDummyMainTypeEntity> DummyMainList { get; } = new();

    #endregion Navigation properties
}
