// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.DummyManyToOne;

/// <summary>
/// Сущность типа "Фиктивное отношение многие к одному" сопоставителя.
/// </summary>
public class MapperDummyManyToOneTypeEntity : DummyManyToOneTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Фиктивное главное".
    /// </summary>
    public MapperDummyMainTypeEntity? DummyMain { get; set; }

    #endregion Navigation properties
}