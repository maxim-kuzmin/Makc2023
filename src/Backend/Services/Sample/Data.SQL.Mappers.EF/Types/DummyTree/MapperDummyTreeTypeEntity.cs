// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyTree;

/// <summary>
/// Сущность типа "Фиктивное дерево" сопоставителя.
/// </summary>
public class MapperDummyTreeTypeEntity : DummyTreeTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список дочерних экземпляров сущности "Фиктивное дерево".
    /// </summary>
    public List<MapperDummyTreeTypeEntity> DummyTreeChildList { get; } = new();

    /// <summary>
    /// Список экземпляров сущности "Связь фиктивного дерева" по идентификатору.
    /// </summary>
    public List<MapperDummyTreeLinkTypeEntity> DummyTreeLinkByIdList { get; } = new();

    /// <summary>
    /// Список экземпляров сущности "Связь фиктивного дерева" по идентификатору родителя.
    /// </summary>
    public List<MapperDummyTreeLinkTypeEntity>? DummyTreeLinkByParentIdList { get; } = new();

    /// <summary>
    /// Родительский экземпляр сущности "Фиктивное дерево".
    /// </summary>
    public MapperDummyTreeTypeEntity? DummyTreeParent { get; set; }

    #endregion Navigation properties
}
