// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyTreeLink;

/// <summary>
/// Сущность типа "Связь фиктивного дерева" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyTreeLinkTypeEntity : DummyTreeLinkTypeEntity
{
    #region Navigation properties

    /// <summary>
    ///  Экземпляр сущности "Фиктивное дерево" по идентификатору.
    /// </summary>
    public ClientMapperDummyTreeTypeEntity? DummyTreeById { get; set; }

    /// <summary>
    ///  Экземпляр сущности "Фиктивное дерево" по идентификатору родителя.
    /// </summary>
    public ClientMapperDummyTreeTypeEntity? DummyTreeByParentId { get; set; }

    #endregion Navigation properties
}
