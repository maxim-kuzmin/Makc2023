// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using NLog.Web;

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Setup;

/// <summary>
/// Расширение ведения журнала в веб-приложении.
/// </summary>
public static class WebAppSetupExtension
{
    #region Public methods

    /// <summary>
    /// Настроить.
    /// </summary>
    /// <param name="appBuilder">Построитель приложения.</param>
    public static void Configure(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Logging.ClearProviders();

        appBuilder.Host.UseNLog();
    }

    #endregion Public methods
}
