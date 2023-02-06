// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.App;

/// <summary>
/// Ресурс приложения.
/// </summary>
public class AppResource : IAppResource
{
    #region Properties

    private IStringLocalizer<AppResource> Localizer { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public AppResource(IStringLocalizer<AppResource> localizer)
    {
        Localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForNotImportedTypes(IEnumerable<Type> types)
    {
        return Localizer["@@ErrorMessageForNotImportedTypes", string.Join(", ", types)];
    }

    #endregion Public methods
}
