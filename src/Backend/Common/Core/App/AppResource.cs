// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.App;

/// <summary>
/// Ресурс приложения.
/// </summary>
public class AppResource : IAppResource
{
    #region Fields

    private readonly IStringLocalizer _localizer;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public AppResource(IStringLocalizer<AppResource> localizer)
    {
        _localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForNotImportedTypes(IEnumerable<Type> types)
    {
        return _localizer["@@ErrorMessageForNotImportedTypes", string.Join(", ", types)];
    }

    #endregion Public methods
}
