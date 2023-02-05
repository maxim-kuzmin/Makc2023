// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Types.DummyTreeLink;

/// <summary>
/// Сущность типа "Связь фиктивного дерева" сопоставителя.
/// </summary>
public class MapperDummyTreeLinkTypeEntity : DummyTreeLinkTypeEntity
{
    #region Navigation properties

    /// <summary>
    ///  Экземпляр сущности "Фиктивное дерево" по идентификатору.
    /// </summary>
    public MapperDummyTreeTypeEntity? DummyTreeById { get; set; }

    /// <summary>
    ///  Экземпляр сущности "Фиктивное дерево" по идентификатору родителя.
    /// </summary>
    public MapperDummyTreeTypeEntity? DummyTreeByParentId { get; set; }

    #endregion Navigation properties
}
