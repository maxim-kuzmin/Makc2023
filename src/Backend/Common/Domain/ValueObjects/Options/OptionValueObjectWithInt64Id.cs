// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.ValueObjects.Options;

/// <summary>
/// Объект-значение параметра с 64-битным целочисленным идентификатором.
/// </summary>
public class OptionValueObjectWithInt64Id : OptionValueObjectWithNumberId<long>
{
    #region Constructors

    /// <inheritdoc/>
    public OptionValueObjectWithInt64Id(long id, string name) : base(id, name)
    {
    }

    #endregion Constructors
}
