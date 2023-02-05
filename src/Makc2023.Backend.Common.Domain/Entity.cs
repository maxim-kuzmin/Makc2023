// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain;

/// <summary>
/// Сущность.
/// </summary>
public abstract class Entity<T> : IEntity
{
    #region Fields

    private List<INotification>? _events;

    int? _hashCode;

    #endregion Fields

    #region Operators

    /// <summary>
    /// Оператор равенства.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат проверки на равенство.</returns>
    public static bool operator ==(Entity<T> left, Entity<T> right)
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
    public static bool operator !=(Entity<T> left, Entity<T> right)
    {
        return !(left == right);
    }

    #endregion Operators

    #region Public methods

    /// <summary>
    /// Добавить событие.
    /// </summary>
    /// <param name="eventItem"></param>
    public void AddEvent(INotification eventItem)
    {
        _events ??= new List<INotification>();

        _events.Add(eventItem);
    }

    /// <inheritdoc/>
    public void ClearEvents()
    {
        _events?.Clear();
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj == null || obj is not Entity<T>)
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

        Entity<T> item = (Entity<T>)obj;

        if (item.IsTransient() || IsTransient())
        {
            return false;
        }
        else
        {
            return item.GetId()!.Equals(GetId());
        }
    }

    /// <inheritdoc/>
    public IReadOnlyCollection<INotification>? GetEvents() => _events?.AsReadOnly();

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        if (IsTransient())
        {
            return base.GetHashCode();
        }
        else
        {
            if (!_hashCode.HasValue)
            {
                _hashCode = GetId()!.GetHashCode() ^ 31; // XOR for random distribution (https://ericlippert.com/2011/02/28/guidelines-and-rules-for-gethashcode/)
            }

            return _hashCode.Value;
        }
    }

    /// <summary>
    /// Проверить на транзитивность.
    /// </summary>
    /// <returns>Признак транзитивности.</returns>
    public bool IsTransient()
    {
        T id = GetId();

        return id is null || id.Equals(default);
    }

    /// <summary>
    /// Удалить событие.
    /// </summary>
    /// <param name="eventItem">Событие.</param>
    public void RemoveEvent(INotification eventItem)
    {
        _events?.Remove(eventItem);
    }

    #endregion Public methods

    #region Protected methods

    /// <summary>
    /// Получить идентификатор.
    /// </summary>
    protected abstract T GetId();

    #endregion Protected methods
}
