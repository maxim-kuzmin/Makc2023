// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using NLog.Extensions.Logging;

namespace Makc2023.Backend.Common.Core.Apps.ConsoleApp.Setup;

/// <summary>
/// Расширения ведения журнала в консольном приложении.
/// </summary>
public static class ConsoleAppLoggingExtensions
{
    #region Public methods

    /// <summary>
    /// Настроить.
    /// </summary>
    /// <param name="services">Сервисы.</param>
    public static void Configure(this IServiceCollection services)
    {
        var config = AppHelper.CreateConfiguration();

        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();

            loggingBuilder.SetMinimumLevel(LogLevel.Trace);

            loggingBuilder.AddNLog(config);
        });
    }

    #endregion Public methods
}
