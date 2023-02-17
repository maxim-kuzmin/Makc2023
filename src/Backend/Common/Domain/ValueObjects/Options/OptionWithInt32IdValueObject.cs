// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.ValueObjects.Options;

/// <summary>
/// Объект-значение параметра с 32-битным целочисленным идентификатором.
/// </summary>
public class OptionWithInt32IdValueObject : OptionWithStructIdValueObject<int>
{
    #region Constructors

    /// <inheritdoc/>
    public OptionWithInt32IdValueObject(int id, string name) : base(id, name)
    {
    }

    #endregion Constructors
}
