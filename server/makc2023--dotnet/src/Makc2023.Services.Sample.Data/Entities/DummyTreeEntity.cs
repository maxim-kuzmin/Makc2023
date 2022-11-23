// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Entities;

/// <summary>
/// Сущность "Фиктивное дерево".
/// 
/// Служит для демонстрации иерархической структуры данных.
/// </summary>
public class DummyTreeEntity : Entity<long>, IAggregateRoot
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; private set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Идентификатор родителя.
    /// </summary>
    public long? ParentId { get; private set; }

    /// <summary>
    /// Число детей в дереве.
    /// </summary>
    public long TreeChildCount { get; private set; }

    /// <summary>
    /// Число потомков в дереве.
    /// </summary>
    public long TreeDescendantCount { get; private set; }

    /// <summary>
    /// Уровень в дереве.
    /// </summary>
    public long TreeLevel { get; private set; }

    /// <summary>
    /// Позиция в дереве.
    /// </summary>
    public string TreePath { get; private set; }

    /// <summary>
    /// Позиция в дереве.
    /// </summary>
    public int TreePosition { get; private set; }

    /// <summary>
    /// Сортировка в дереве.
    /// </summary>
    public string TreeSort { get; private set; }

    #endregion Properties    

    #region Navigation properties

    /// <summary>
    /// Список дочерних экземпляров сущности "Фиктивное дерево".
    /// </summary>
    public List<DummyTreeEntity>? DummyTreeChildList { get; set; }

    /// <summary>
    /// Список экземпляров соединения "Связь фиктивного дерева" по идентификатору.
    /// </summary>
    public List<DummyTreeLinkJoin>? DummyTreeLinkByIdList { get; set; }

    /// <summary>
    /// Список экземпляров соединения "Связь фиктивного дерева" по идентификатору родителя.
    /// </summary>
    public List<DummyTreeLinkJoin>? DummyTreeLinkByParentIdList { get; set; }

    /// <summary>
    /// Родительский экземпляр сущности "Фиктивное дерево".
    /// </summary>
    public DummyTreeEntity? DummyTreeParent { get; set; }

    #endregion Navigation properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в свойстве, которое не должно его содержать.
    /// </exception>
    /// <exception cref="NullReferenceException">
    /// Возникает, если NULL содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected DummyTreeEntity()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new NullReferenceException(nameof(Name));
        }

        if (ParentId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(ParentId));
        }

        if (string.IsNullOrWhiteSpace(TreePath))
        {
            throw new NullReferenceException(nameof(TreePath));
        }

        if (string.IsNullOrWhiteSpace(TreeSort))
        {
            throw new NullReferenceException(nameof(TreeSort));
        }
    }

    public DummyTreeEntity(
        string name,
        long? parentId,
        long treeChildCount,
        long treeDescendantCount,
        long treeLevel,
        string treePath,
        int treePosition,
        string treeSort) : this()
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;

        ParentId = parentId is not null && parentId < 1
            ? throw new ArgumentOutOfRangeException(nameof(parentId))
            : parentId;

        TreeChildCount = treeChildCount;

        TreeDescendantCount = treeDescendantCount;

        TreeLevel = treeLevel;

        TreePath = string.IsNullOrWhiteSpace(treePath)
            ? throw new ArgumentNullException(nameof(treePath))
            : treePath;

        TreePosition = treePosition;

        TreeSort = string.IsNullOrWhiteSpace(treeSort)
            ? throw new ArgumentNullException(nameof(treeSort))
            : treeSort;
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Id;

    #endregion Protected methods
}
