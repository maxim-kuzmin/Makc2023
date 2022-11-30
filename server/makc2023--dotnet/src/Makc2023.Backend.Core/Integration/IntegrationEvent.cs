// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Core.Integration;

/// <summary>
/// Событие интеграции.
/// </summary>
public record IntegrationEvent
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    [JsonInclude]
    public Guid Id { get; private init; }

    /// <summary>
    /// Дата создания.
    /// </summary>
    [JsonInclude]
    public DateTime CreationDate { get; private init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    public IntegrationEvent() : this(Guid.NewGuid(), DateTime.UtcNow)
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="createDate">Дата создания.</param>
    [JsonConstructor]
    public IntegrationEvent(Guid id, DateTime createDate)
    {
        Id = id;
        CreationDate = createDate;
    }

    #endregion Constructors
}
