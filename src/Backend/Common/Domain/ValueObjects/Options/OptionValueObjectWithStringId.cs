// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.ValueObjects.Options;

/// <summary>
/// Объект-значение параметра с идентификатором строкового типа.
/// </summary>
public class OptionValueObjectWithStringId : OptionValueObject<string>
{
    #region Constructors

    /// <inheritdoc/>
    public OptionValueObjectWithStringId(string id, string name) : base(id, name)
    {
    }

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
