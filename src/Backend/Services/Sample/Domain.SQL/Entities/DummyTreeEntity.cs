// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Entities;

/// <summary>
/// Сущность "Фиктивное дерево".
/// </summary>
public class DummyTreeEntity : Entity<long>, IAggregateRoot
{
    #region Fields

    private readonly List<DummyTreeEntity> _dummyTreeChildList = new();

    #endregion Fields

    #region Properties

    /// <summary>
    /// Данные.
    /// </summary>
    public DummyTreeTypeEntity Data { get; }

    /// <summary>
    /// Список дочерних экземпляров сущности "Фиктивное дерево".
    /// </summary>
    public IReadOnlyCollection<DummyTreeEntity> DummyTreeChildList => _dummyTreeChildList;

    /// <summary>
    /// Родительский экземпляр сущности "Фиктивное дерево".
    /// </summary>
    public DummyTreeEntity? DummyTreeParent { get; set; }

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data">Данные.</param>
    public DummyTreeEntity(DummyTreeTypeEntity? data = null)
    {
        Data = data ?? new DummyTreeTypeEntity();
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Добавить дочерний экземпляр сущности "Фиктивное дерево".
    /// </summary>
    /// <param name="data">Данные.</param>
    /// <returns>Добавленный экземпляр.</returns>
    public DummyTreeEntity AddDummyChildTree(DummyTreeTypeEntity data)
    {
        var result = _dummyTreeChildList.Where(x => x.Data.Name == data.Name).SingleOrDefault();

        if (result is null)
        {
            data.ParentId = GetId();

            result = new DummyTreeEntity(data);

            _dummyTreeChildList.Add(result);
        }

        return result;
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Data.Id;

    #endregion Protected methods
}
