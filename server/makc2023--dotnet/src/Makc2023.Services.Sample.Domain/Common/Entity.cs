namespace Makc2023.Services.Sample.Domain.Common;

/// <summary>
/// Сущность.
/// </summary>
public abstract class Entity
{
    #region Fields

    private List<INotification>? _domainEvents;

    int _id;

    int? _requestedHashCode;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Доменные события.
    /// </summary>
    public IReadOnlyCollection<INotification>? DomainEvents => _domainEvents?.AsReadOnly();

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public virtual int Id
    {
        get
        {
            return _id;
        }
        protected set
        {
            _id = value;
        }
    }

    #endregion Properties

    #region Operators

    /// <summary>
    /// Оператор равенства.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат проверки на равенство.</returns>
    public static bool operator ==(Entity left, Entity right)
    {
        if (Equals(left, null))
        {
            return (Equals(right, null));
        }
        else
        {
            return left.Equals(right);
        }
    }

    /// <summary>
    /// Оператор неравенства.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат проверки на неравенство.</returns>
    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

    #endregion Operators

    #region Public methods

    /// <summary>
    /// Добавить доменное событие.
    /// </summary>
    /// <param name="eventItem"></param>
    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents ??= new List<INotification>();

        _domainEvents.Add(eventItem);
    }

    /// <summary>
    /// Очистить доменные события.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Entity)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        Entity item = (Entity)obj;

        if (item.IsTransient() || IsTransient())
        {
            return false;
        }
        else
        {
            return item.Id == Id;
        }
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
            {
                _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution (https://ericlippert.com/2011/02/28/guidelines-and-rules-for-gethashcode/)
            }

            return _requestedHashCode.Value;
        }
        else
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Проверить на транзитивность.
    /// </summary>
    /// <returns>Признак транзитивности.</returns>
    public bool IsTransient()
    {
        return Id == default;
    }

    /// <summary>
    /// Удалить доменное событие.
    /// </summary>
    /// <param name="eventItem">Событие.</param>
    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    #endregion Public methods
}
