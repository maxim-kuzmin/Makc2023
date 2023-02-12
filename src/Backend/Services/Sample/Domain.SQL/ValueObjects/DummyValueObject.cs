// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.ValueObjects;

/// <summary>
/// Фиктивный объект-значение.
/// </summary>
public class DummyValueObject : ValueObject
{
    #region Properties

    /// <summary>
    /// Свойство 1.
    /// </summary>
    public string Prop1 { get; private set; }

    /// <summary>
    /// Свойство 2.
    /// </summary>
    public string Prop2 { get; private set; }

    /// <summary>
    /// Свойство 3.
    /// </summary>
    public string Prop3 { get; private set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="prop1">Свойство 1.</param>
    public DummyValueObject(string prop1, string prop2, string prop3) =>
        (Prop1, Prop2, Prop3) = (prop1, prop2, prop3);

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Prop1;
        yield return Prop2;
        yield return Prop3;
    }

    #endregion Protected methods
}
