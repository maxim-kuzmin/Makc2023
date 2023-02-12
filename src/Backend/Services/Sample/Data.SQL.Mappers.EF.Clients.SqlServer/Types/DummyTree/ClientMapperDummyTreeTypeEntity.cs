// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyTree;

/// <summary>
/// Сущность типа "Фиктивное дерево" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyTreeTypeEntity : DummyTreeTypeEntity
{
    #region Navigation properties

    /// <summary>
    /// Список дочерних экземпляров сущности "Фиктивное дерево".
    /// </summary>
    public List<ClientMapperDummyTreeTypeEntity> DummyTreeChildList { get; } = new();

    /// <summary>
    /// Список экземпляров сущности "Связь фиктивного дерева" по идентификатору.
    /// </summary>
    public List<ClientMapperDummyTreeLinkTypeEntity> DummyTreeLinkByIdList { get; } = new();

    /// <summary>
    /// Список экземпляров сущности "Связь фиктивного дерева" по идентификатору родителя.
    /// </summary>
    public List<ClientMapperDummyTreeLinkTypeEntity>? DummyTreeLinkByParentIdList { get; } = new();

    /// <summary>
    /// Родительский экземпляр сущности "Фиктивное дерево".
    /// </summary>
    public ClientMapperDummyTreeTypeEntity? DummyTreeParent { get; set; }

    #endregion Navigation properties
}
