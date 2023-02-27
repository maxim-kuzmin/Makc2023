// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core;

/// <summary>
/// Именованные значения.
/// </summary>
/// <typeparam name="TValue">Тип значения.</typeparam>
public class NamedValues<TValue>
{
    #region Properties

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Значения.
    /// </summary>
    public List<TValue> Values { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="values">Значения.</param>
    public NamedValues(string name, List<TValue>? values = null)
    {
        Name = name;
        Values = values ?? new();
    }

    #endregion Constructors
}
