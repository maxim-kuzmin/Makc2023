namespace Makc2023.Services.Sample.Domain.Entities;

/// <summary>
/// Сущность "Пользователь".
/// 
/// Учётная запись, используемая приложением для проверки прав доступа.
/// </summary>
public class UserEntity : Entity<int>
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
    /// Адрес электронной почты.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Признак блокировки.
    /// </summary>
    public bool IsBlocked { get; private set; }

    #endregion Properties    

    #region Navigation properties

    /// <summary>
    /// Список элементов сущности "Внутреннее разрешение".
    /// </summary>
    public ICollection<InternalPermissionEntity>? InternalPermissionList { get; set; }

    /// <summary>
    /// Список элементов соединения "Внутреннее разрешение пользователя".
    /// </summary>
    public List<UserInternalPermissionJoin>? UserInternalPermissionList { get; set; }

    #endregion Navigation properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="NullReferenceException">
    /// Возникает, если NULL содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected UserEntity()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new NullReferenceException(nameof(Name));
        }

        if (string.IsNullOrWhiteSpace(Email))
        {
            throw new NullReferenceException(nameof(Email));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="email">Адрес электронной почты.</param>
    /// <param name="isBlocked">Признак блокировки.</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public UserEntity(string name, string email, bool isBlocked) : this()
    {
        Name = string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException(nameof(name))
            : name;

        Email = string.IsNullOrWhiteSpace(email)
            ? throw new ArgumentNullException(nameof(email))
            : email;

        IsBlocked = isBlocked;
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override int GetId() => Id;

    #endregion Protected methods
}