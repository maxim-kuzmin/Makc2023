// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Entities;

/// <summary>
/// Сущность "Фиктивное главное".
/// </summary>
public class DummyMainEntity : Entity<long>, IAggregateRoot
{
    #region Fields

    private readonly List<DummyManyToOneEntity> _dummyManyToOneList = new();

    private readonly List<DummyManyToManyEntity> _dummyManyToManyList = new();

    #endregion Fields

    #region Properties

    /// <summary>
    /// Данные.
    /// </summary>
    public DummyMainTypeEntity Data { get; }

    /// <summary>
    /// Список элементов сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public IReadOnlyCollection<DummyManyToManyEntity> DummyManyToManyList => _dummyManyToManyList;

    /// <summary>
    /// Список элементов сущности "Фиктивное отношение многие к одному".
    /// </summary>
    public IReadOnlyCollection<DummyManyToOneEntity> DummyManyToOneList => _dummyManyToOneList;

    /// <summary>
    /// Экземпляр сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public DummyOneToManyEntity? DummyOneToMany { get; set; }

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data">Данные.</param>
    public DummyMainEntity(DummyMainTypeEntity? data = null)
    {
        Data = data ?? new DummyMainTypeEntity();
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Добавить экземпляр сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    /// <param name="data">Данные.</param>
    /// <returns>Добавленный экземпляр.</returns>
    public DummyManyToManyEntity AddDummyManyToMany(DummyManyToManyTypeEntity data)
    {
        var result = _dummyManyToManyList.Where(x => x.Data.Id == data.Id).SingleOrDefault();

        if (result is null)
        {
            result = new DummyManyToManyEntity(data);

            _dummyManyToManyList.Add(result);
        }

        return result;
    }

    /// <summary>
    /// Добавить экземпляр сущности "Фиктивное отношение многие к одному".
    /// </summary>
    /// <param name="data">Данные.</param>
    /// <returns>Добавленный экземпляр.</returns>
    public DummyManyToOneEntity AddDummyManyToOne(DummyManyToOneTypeEntity data)
    {
        var result = _dummyManyToOneList.Where(x => x.Data.Name == data.Name).SingleOrDefault();

        if (result is null)
        {
            data.DummyMainId = GetId();

            result = new DummyManyToOneEntity(data);

            _dummyManyToOneList.Add(result);
        }

        return result;
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Data.Id;

    #endregion Protected methods
}
