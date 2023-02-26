// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL;

/// <summary>
/// Ресурс.
/// </summary>
public class Resource : IResource
{
    #region Fields

    private readonly IStringLocalizer _localizer;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public Resource(IStringLocalizer<Resource> localizer)
    {
        _localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetValidValueForId()
    {
        return _localizer["@@ValidValueForId"];
    }

    /// <inheritdoc/>
    public string GetValidValueForSortField(string asc, string desc)
    {
        return _localizer["@@ValidValueForSortField", asc, desc];
    }

    #endregion Public methods
}
