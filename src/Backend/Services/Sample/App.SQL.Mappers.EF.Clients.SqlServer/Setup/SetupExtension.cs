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
    /// <param name="appEnvironment">Окружение приложения.</param>
    public static void AddAppModules(this WebApplicationBuilder appBuilder, IAppEnvironment appEnvironment)
    {
        appBuilder.Configure();

        var configuration = appBuilder.Configuration;

        appBuilder.Services.AddAppModules(new AppModule[]
        {
            new ModuleOfCommonCore(configuration.GetRequiredSection("App:Common:Core")),
            new ModuleOfCommonDataSQL(configuration.GetRequiredSection("App:Common:Data:SQL")),
            new ModuleOfCommonDataSQLClientsSqlServer(),
            new ModuleOfCommonDataSQLMappersEF(),
            new ModuleOfServiceApp(appEnvironment),
            new ModuleOfServiceDataSQLClientsSqlServer(),
            new ModuleOfServiceDataSQL(configuration.GetRequiredSection("App:Service:Data:SQL")),
            new ModuleOfServiceDataSQLMappersEFClientsSqlServer(),
            new ModuleOfServiceDomainsDummyMain()
        });

        // Add services to the container.

        appBuilder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        appBuilder.Services.AddEndpointsApiExplorer();
        appBuilder.Services.AddSwaggerGen();
    }

    /// <summary>
    /// Использовать модули приложения.
    /// </summary>
    /// <param name="app">Приложение.</param>
    /// <param name="appEnvironment">Окружение приложения.</param>
    /// <returns>Задача на использование.</returns>
    public static Task UseAppModules(this WebApplication app, IAppEnvironment appEnvironment)
    {
        app.UseRequestLocalization(x => x.SetDefaultCulture(appEnvironment.DefaultCulture)
            .AddSupportedCultures(appEnvironment.SupportedCultures)
            .AddSupportedUICultures(appEnvironment.SupportedCultures));

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        var setupService = app.Services.GetRequiredService<SetupService>();

        return setupService.Execute();
    }

    #endregion Public methods
}
