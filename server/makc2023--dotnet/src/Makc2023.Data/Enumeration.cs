// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data;

/// <summary>
/// Перечисление.
/// </summary>
public abstract class Enumeration : IComparable
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
    /// <param name="id">Идентификатор.</param>
    /// <param name="name">Имя.</param>
    protected Enumeration(int id, string name) => (Id, Name) = (id, name);

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Абсолютная разница.
    /// </summary>
    /// <param name="firstValue">Первое значение.</param>
    /// <param name="secondValue">Второе значение.</param>
    /// <returns>Разница между первым и вторым значением.</returns>
    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
        return Math.Abs(firstValue.Id - secondValue.Id);
    }

    /// <inheritdoc/>
    public int CompareTo(object? other) => Id.CompareTo(((Enumeration)other!).Id);

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());

        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    /// <inheritdoc/>
    public override int GetHashCode() => Id.GetHashCode();

    /// <inheritdoc/>
    public override string ToString() => Name;

    #endregion Public methods
}
