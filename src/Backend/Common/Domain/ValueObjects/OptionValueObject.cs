// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Domain.ValueObjects;

/// <summary>
/// Объект-значение параметра.
/// </summary>
/// <typeparam name="TId">Тип идентификатора.</typeparam>
public abstract class OptionValueObject<TId> : ValueObject
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public TId Id { get; private set; }

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
    public OptionValueObject(TId id, string name) =>
        (Id, Name) = (id, name);

    #endregion Constructors
}
