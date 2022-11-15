﻿namespace Makc2023.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Фиктивное отношение многие ко многим".
/// 
/// Служит для демонстрации связи многих экземпляров одной сущности
/// со многими экземплярами другой сущности.
/// 
/// Многие экземпляры сущности "Фиктивное отношение многие ко многим"
/// связаны со многими экземплярами сущности "Фиктивное главное".
/// </summary>
public class DummyManyToManyEntity : Entity<int>
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    #endregion Properties    

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
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public DummyManyToManyEntity(string name)
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;
    }

    #endregion Constructors

    #region Public methods

        /// <inheritdoc/>
    protected override int GetId() => Id;

    #endregion Public methods
}