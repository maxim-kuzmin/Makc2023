 // Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain;

/// <summary>
/// Ресурс домена.
/// </summary>
public class DummyMainDomainResource : IDummyMainDomainResource
{
    #region Fields

    private readonly IStringLocalizer _localizer;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public DummyMainDomainResource(IStringLocalizer<DummyMainDomainResource> localizer)
    {
        _localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetItemGetOperationName()
    {
        return _localizer["@@ItemGetOperationName"];
    }

    /// <inheritdoc/>
    public string GetListGetOperationName()
    {
        return _localizer["@@ListGetOperationName"];
    }

    #endregion Public methods
}
