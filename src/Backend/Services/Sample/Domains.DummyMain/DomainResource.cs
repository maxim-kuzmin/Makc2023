﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain;

/// <summary>
/// Ресурс домена.
/// </summary>
public class DomainResource : IDomainResource
{
    #region Properties

    private IStringLocalizer<DomainResource> Localizer { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public DomainResource(IStringLocalizer<DomainResource> localizer)
    {
        Localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForEntityNotFound()
    {
        return Localizer["@@ErrorMessageForEntityNotFound"];
    }

    /// <inheritdoc/>
    public string GetItemGetOperationName()
    {
        return Localizer["@@ItemGetOperationName"];
    }

    /// <inheritdoc/>
    public string GetListGetOperationName()
    {
        return Localizer["@@ListGetOperationName"];
    }

    #endregion Public methods
}
