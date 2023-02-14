// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.App.SQL.Mappers.EF.Clients.SqlServer.Setup;

/// <summary>
/// Расширение настройки.
/// </summary>
public static class SetupExtension
{
    #region Public methods

    /// <summary>
    /// Добавить модули приложения.
    /// </summary>
    /// <param name="appBuilder">Построитель приложения.</param>
    public static void AddAppModules(this WebApplicationBuilder appBuilder)
    {
        var configuration = appBuilder.Configuration;

        appBuilder.Services.AddAppModules(new AppModule[]
        {
            new ModuleOfCommonCore(configuration.GetRequiredSection("App:Common:Core")),
            new ModuleOfCommonDataSQL(configuration.GetRequiredSection("App:Common:Data:SQL")),
            new ModuleOfCommonDataSQLClientsSqlServer(),
            new ModuleOfCommonDataSQLMappersEF(),
            new ModuleOfServiceDataSQLClientsSqlServer(),
            new ModuleOfServiceDataSQL(configuration.GetRequiredSection("App:Service:Data:SQL")),
            new ModuleOfServiceDataSQLMappersEFClientsSqlServer(),
            new ModuleOfServiceDomainsDummyMain()
        });
    }

    /// <summary>
    /// Использовать модули приложения.
    /// </summary>
    /// <param name="app">Приложение.</param>
    /// <param name="appHandler">Обработчик приложения.</param>
    /// <returns>Задача на использование.</returns>
    public static async Task UseAppModules(this WebApplication app, AppHandler appHandler)
    {
        app.UseRequestLocalization(x => x.SetDefaultCulture(appHandler.CurrentLanguage)
            .AddSupportedCultures(appHandler.AvailableLanguages)
            .AddSupportedUICultures(appHandler.AvailableLanguages));

        var setupService = app.Services.GetRequiredService<ISetupService>();

        await setupService.MigrateDatabase().ConfigureAwait(false);

        await setupService.SeedTestData().ConfigureAwait(false);
    }

    #endregion Public methods
}
