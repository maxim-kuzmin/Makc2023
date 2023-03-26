// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.ValueObjects.Options;

/// <summary>
/// Объект-значение параметра с 32-битным целочисленным идентификатором.
/// </summary>
public class OptionValueObjectWithInt32Id : OptionValueObjectWithNumberId<int>
{
    #region Constructors

    /// <inheritdoc/>
    public OptionValueObjectWithInt32Id(int id, string name) : base(id, name)
    {
    }

    #endregion Constructors
}
