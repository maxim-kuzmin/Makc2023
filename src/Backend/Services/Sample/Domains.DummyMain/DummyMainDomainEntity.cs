// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain;

/// <summary>
/// Сущность домена "Фиктивное главное".
/// </summary>
public class DummyMainDomainEntity : Entity<long>, IAggregateRoot
{
    #region Fields

    private readonly List<OptionValueObjectWithInt64Id> _dummyManyToOneList = new();

    private readonly List<OptionValueObjectWithInt64Id> _dummyManyToManyList = new();

    #endregion Fields

    #region Properties

    /// <summary>
    /// Данные.
    /// </summary>
    public DummyMainTypeEntity Data { get; }

    /// <summary>
    /// Список элементов сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public IReadOnlyCollection<OptionValueObjectWithInt64Id> DummyManyToManyList => _dummyManyToManyList;

    /// <summary>
    /// Список элементов сущности "Фиктивное отношение многие к одному".
    /// </summary>
    public IReadOnlyCollection<OptionValueObjectWithInt64Id> DummyManyToOneList => _dummyManyToOneList;

    /// <summary>
    /// Экземпляр сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public OptionValueObjectWithInt64Id? DummyOneToMany { get; set; }

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="data">Данные.</param>
    public DummyMainDomainEntity(DummyMainTypeEntity? data = null)
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
    public OptionValueObjectWithInt64Id AddDummyManyToMany(OptionValueObjectWithInt64Id data)
    {
        var result = _dummyManyToManyList.Where(x => x.Id == data.Id).SingleOrDefault();

        if (result is null)
        {
            _dummyManyToManyList.Add(data);
        }

        return result ?? data;
    }

    /// <summary>
    /// Добавить экземпляр сущности "Фиктивное отношение многие к одному".
    /// </summary>
    /// <param name="data">Данные.</param>
    /// <returns>Добавленный экземпляр.</returns>
    public OptionValueObjectWithInt64Id AddDummyManyToOne(OptionValueObjectWithInt64Id data)
    {
        var result = _dummyManyToOneList.Where(x => x.Name == data.Name).SingleOrDefault();

        if (result is null)
        {
            _dummyManyToOneList.Add(data);
        }

        return result ?? data;
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Data.Id;

    #endregion Protected methods
}
