﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Mappers.EF;

/// <summary>
/// Ресурс сопоставителя.
/// </summary>
public class MapperResource : IMapperResource
{
    #region Fields

    private readonly IStringLocalizer _localizer;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public MapperResource(IStringLocalizer<MapperResource> localizer)
    {
        _localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForExternalTransaction(Guid transactionId)
    {
        return _localizer["@@ErrorMessageForExternalTransaction", transactionId];
    }

    #endregion Public methods
}
