// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Entities;

/// <summary>
/// Сущность "Фиктивное отношение многие ко многим".
/// 
/// Служит для демонстрации связи многих экземпляров одной сущности
/// со многими экземплярами другой сущности.
/// 
/// Многие экземпляры сущности "Фиктивное отношение многие ко многим"
/// связаны со многими экземплярами сущности "Фиктивное главное".
/// </summary>
public class DummyManyToManyEntity : Entity<long>, IAggregateRoot
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

    #endregion Properties    

    #region Navigation properties

    /// <summary>
    /// Список экземпляров сущности "Фиктивное главное".
    /// </summary>
    public ICollection<DummyMainEntity>? DummyMainList { get; set; }

    /// <summary>
    /// Список экземпляров соединения "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public List<DummyMainDummyManyToManyJoin>? DummyMainDummyManyToManyList { get; set; }

    #endregion Navigation properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="NullReferenceException">
    /// Возникает, если NULL содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected DummyManyToManyEntity()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new NullReferenceException(nameof(Name));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public DummyManyToManyEntity(string name) : this()
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Id;

    #endregion Protected methods
}