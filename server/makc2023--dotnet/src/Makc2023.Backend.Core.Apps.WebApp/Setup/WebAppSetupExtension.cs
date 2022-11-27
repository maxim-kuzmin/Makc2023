// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using NLog.Web;

namespace Makc2023.Backend.Core.Apps.WebApp.Setup;

/// <summary>
/// Расширение ведения журнала в веб-приложении.
/// </summary>
public static class WebAppSetupExtension
{
    #region Public methods

    /// <summary>
    /// Настроить.
    /// </summary>
    /// <param name="services">Сервисы.</param>
    public static void Configure(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();

        builder.Host.UseNLog();
    }

    #endregion Public methods
}
