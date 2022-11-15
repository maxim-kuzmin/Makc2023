﻿namespace Makc2023.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Фиктивное дерево".
/// 
/// Служит для демонстрации иерархической структуры данных.
/// </summary>
public class DummyTreeEntity : Entity<int>
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Идентификатор родителя.
    /// </summary>
    public int? ParentId { get; private set; }

    /// <summary>
    /// Число детей в дереве.
    /// </summary>
    public int TreeChildCount { get; private set; }

    /// <summary>
    /// Число потомков в дереве.
    /// </summary>
    public int TreeDescendantCount { get; private set; }

    /// <summary>
    /// Уровень в дереве.
    /// </summary>
    public int TreeLevel { get; private set; }

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
        int? parentId,
        int treeChildCount,
        int treeDescendantCount,
        int treeLevel,
        string treePath,
        int treePosition,
        string treeSort)
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

    #region Public methods

    /// <inheritdoc/>
    protected override int GetId() => Id;

    #endregion Public methods
}