// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Entities;

/// <summary>
/// Сущность "Внутреннее разрешение".
/// 
/// Разрешение внутри сервиса на действие во внутреннем домене.
/// </summary>
public class InternalPermissionEntity : Entity<long>
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
    /// Идентификатор экземпляра сущности "Внутренний домен".
    /// </summary>
    public long InternalDomainId { get; private set; }

    #endregion Properties    

    #region Navigation properties

    /// <summary>
    /// Экземпляр сущности "Внутренний домен".
    /// </summary>
    public InternalDomainEntity? InternalDomain { get; set; }

    /// <summary>
    /// Список экземпляров соединения "Внутреннее разрешение пользователя".
    /// </summary>
    public List<UserInternalPermissionJoin>? UserInternalPermissionList { get; set; }

    /// <summary>
    /// Список экземпляров сущности "Пользователь".
    /// </summary>
    public ICollection<UserEntity>? UserList { get; set; }

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
    protected InternalPermissionEntity()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new NullReferenceException(nameof(Name));
        }

        if (InternalDomainId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(InternalDomainId));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="internalDomainId">Идентификатор экземпляра сущности "Внутренний домен".</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public InternalPermissionEntity(string name, long internalDomainId) : this()
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;

        InternalDomainId = internalDomainId < 1
            ? throw new ArgumentOutOfRangeException(nameof(internalDomainId))
            : internalDomainId;
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override long GetId() => Id;

    #endregion Protected methods
}