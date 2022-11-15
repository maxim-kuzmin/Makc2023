namespace Makc2023.Services.Sample.Domain.Joins;

/// <summary>
/// Соединение "Внутреннее разрешение пользователя".
/// 
/// Связывает экземпляр сущности "Пользователь" с экземпляром сущности "Внутреннее разрешение".
///
/// Используется для разграничения прав доступа в доменах сервиса.
/// </summary>
public class UserInternalPermissionJoin
{
    #region Properties

    /// <summary>
    /// Идентификатор экземпляра сущности "Пользователь".
    /// </summary>
    public int UserId { get; private set; }

    /// <summary>
    /// Идентификатор экземпляра сущности "Внутреннее разрешение".
    /// </summary>
    public int InternalPermissionId { get; private set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в свойстве, которое не должно его содержать.
    /// </exception>
    protected UserInternalPermissionJoin()
    {
        if (UserId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(UserId));
        }

        if (InternalPermissionId < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(InternalPermissionId));
        }
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="userId">Идентификатор экземпляра сущности "Пользователь".</param>
    /// <param name="internalPermissionId">Идентификатор экземпляра сущности "Внутреннее разрешение".</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Возникает, если ненулевое значение содержится в аргументе, который не должен его содержать.
    /// </exception>
    public UserInternalPermissionJoin(int userId, int internalPermissionId)
    {
        UserId = userId < 1
            ? throw new ArgumentOutOfRangeException(nameof(userId))
            : userId;

        InternalPermissionId = internalPermissionId < 1
            ? throw new ArgumentOutOfRangeException(nameof(internalPermissionId))
            : internalPermissionId;
    }

    #endregion Constructors
}
