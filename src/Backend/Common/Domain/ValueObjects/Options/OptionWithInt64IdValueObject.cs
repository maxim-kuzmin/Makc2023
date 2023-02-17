// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.ValueObjects.Options;

/// <summary>
/// Объект-значение параметра с 64-битным целочисленным идентификатором.
/// </summary>
public class OptionWithInt64IdValueObject : OptionWithStructIdValueObject<long>
{
    #region Constructors

    /// <inheritdoc/>
    public OptionWithInt64IdValueObject(long id, string name) : base(id, name)
    {
    }

    #endregion Constructors
}
