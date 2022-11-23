// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Entities;

/// <summary>
/// Сущность "Фиктивное отношение многие к одному".
/// 
/// Служит для демонстрации связи многих экземпляров одной сущности
/// со одним экземпляром другой сущности.
/// 
/// Многие экземпляры сущности "Фиктивное отношение многие к одному"
/// связаны с одним экземпляром сущности "Фиктивное главное".
/// </summary>
public class DummyManyToOneEntity : Entity<long>
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
    /// Идентификатор экземпляра сущности "Фиктивное главное".
    /// </summary>
    public long DummyMainId { get; private set; }

    #endregion Properties    

    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Фиктивное главное".
    /// </summary>
    public DummyMainEntity? DummyMain { get; set; }

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
    protected DummyManyToOneEntity()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new NullReferenceException(nameof(Name));
        }

        if (DummyMainId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(DummyMainId));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="dummyMainId">Идентификатор экземпляра сущности "Фиктивное главное".</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public DummyManyToOneEntity(string name, long dummyMainId) : this()
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;

        DummyMainId = dummyMainId < 1
            ? throw new ArgumentOutOfRangeException(nameof(dummyMainId))
            : dummyMainId;
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Id;

    #endregion Protected methods
}