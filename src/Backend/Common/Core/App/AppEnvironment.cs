// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.App;

/// <summary>
/// Окружение приложения.
/// </summary>
public class AppEnvironment : IAppEnvironment
{
    #region Properties

    /// <inheritdoc/>
    public string DefaultCulture { get; }

    /// <inheritdoc/>
    public string[] SupportedCultures { get; } = new[] { "ru", "en" };

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    public AppEnvironment()
    {
        string? language = Environment.GetEnvironmentVariable("App__Language");

        DefaultCulture = !string.IsNullOrWhiteSpace(language) && SupportedCultures.Contains(language)
            ? language
            : SupportedCultures[0];
    }

    #endregion Constructors
}
