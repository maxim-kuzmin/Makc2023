namespace Makc2023.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Внутреннее разрешение".
/// 
/// Разрешение внутри сервиса на действие во внутреннем домене.
/// </summary>
public class InternalPermissionEntity : Entity<int>
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
    /// Идентификатор экземпляра сущности "Внутренний домен".
    /// </summary>
    public int InternalDomainId { get; private set; }

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
    public InternalPermissionEntity(string name, int internalDomainId)
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;

        InternalDomainId = internalDomainId < 1
            ? throw new ArgumentOutOfRangeException(nameof(internalDomainId))
            : internalDomainId;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    protected override int GetId() => Id;

    #endregion Public methods
}