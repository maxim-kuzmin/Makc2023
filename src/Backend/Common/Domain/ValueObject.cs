// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain;

/// <summary>
/// Объект-значение.
/// </summary>
public abstract class ValueObject
{
    #region Protected methods

    /// <summary>
    /// Оператор сравнения на равенство.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат сравнения.</returns>
    protected static bool EqualOperator(ValueObject left, ValueObject right)
    {
        if (left is null ^ right is null)
        {
            return false;
        }

        return left is null || left.Equals(right);
    }

    /// <summary>
    /// Оператор сравнения на неравенство.
    /// </summary>
    /// <param name="left">Левый операнд.</param>
    /// <param name="right">Правый операнд.</param>
    /// <returns>Результат сравнения.</returns>
    protected static bool NotEqualOperator(ValueObject left, ValueObject right)
    {
        return !(EqualOperator(left, right));
    }

    /// <summary>
    /// Получить компоненты для сравнения.
    /// </summary>
    /// <returns>Компоненты.</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    #endregion Protected methods

    #region Public methods

    /// <summary>
    /// Сравнить на равенство с объектом.
    /// </summary>
    /// <param name="obj">Объект.</param>
    /// <returns>Результат сравнения.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    /// <summary>
    /// Получить копию.
    /// </summary>
    /// <returns>Копия.</returns>
    public ValueObject GetCopy()
    {
        return (MemberwiseClone() as ValueObject)!;
    }

    #endregion Public methods
}
