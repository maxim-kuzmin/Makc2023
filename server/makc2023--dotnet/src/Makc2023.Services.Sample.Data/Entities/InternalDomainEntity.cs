// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Entities;

/// <summary>
/// Сущность "Внутренний домен".
/// 
/// Часть бизнес-логики сервиса, на действия с которой пользователю требуются разрешения.
/// </summary>
public class InternalDomainEntity : Entity<long>
{
    #region Fields

    private readonly List<InternalPermissionEntity> _internalPermissionList;

    #endregion Fields

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
    /// Список экземпляров сущности "Внутреннее разрешение".
    /// </summary>
    public IReadOnlyCollection<InternalPermissionEntity> InternalPermissionList => _internalPermissionList;

    #endregion Navigation properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="NullReferenceException">
    /// Возникает, если NULL содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected InternalDomainEntity()
    {
        _internalPermissionList = new();

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
    public InternalDomainEntity(string name) : this()
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