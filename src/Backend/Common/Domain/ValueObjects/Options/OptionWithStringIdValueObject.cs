// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.ValueObjects.Options;

/// <summary>
/// Объект-значение параметра с идентификатором строкового типа.
/// </summary>
public class OptionWithStringIdValueObject : ValueObject
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public string Id { get; private set; }

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
    public OptionWithStringIdValueObject(string id, string name) =>
        (Id, Name) = (id, name);

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
        yield return Name;
    }

    #endregion Protected methods
}
