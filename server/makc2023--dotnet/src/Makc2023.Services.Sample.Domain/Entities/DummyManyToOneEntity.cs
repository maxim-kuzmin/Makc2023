﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Фиктивное отношение многие к одному".
/// 
/// Служит для демонстрации связи многих экземпляров одной сущности
/// со одним экземпляром другой сущности.
/// 
/// Многие экземпляры сущности "Фиктивное отношение многие к одному"
/// связаны с одним экземпляром сущности "Фиктивное главное".
/// </summary>
public class DummyManyToOneEntity : Entity<int>
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

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="NullReferenceException">
    /// Возникает, если NULL содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected DummyManyToOneEntity()
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
    public DummyManyToOneEntity(string name) : this()
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override int GetId() => Id;

    #endregion Protected methods
}