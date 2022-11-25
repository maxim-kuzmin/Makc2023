﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.App.Setup;

/// <summary>
/// Расширение настройки.
/// </summary>
public static class SetupExtension
{
    #region Public methods

    /// <summary>
    /// Добавить модули приложения.
    /// </summary>
    /// <param name="services">Сервисы.</param>
    /// <param name="configuration">Конфигурация.</param>
    public static void AddAppModules(this IServiceCollection services, IConfiguration configuration)
    {
        const string root = "Makc2023";

        services.AddAppModules(new AppModule[]
        {
            new CoreModule(configuration.GetRequiredSection($"{root}:Core")),
            new DataSqlModule(configuration.GetRequiredSection($"{root}:Data:Sql")),
            new DataSqlClientsSqlServerModule(),
            new ServicesSampleDataSqlClientsSqlServerModule(),
            new ServicesSampleDataSqlModule(configuration.GetRequiredSection($"{root}:Services:Sample:Data:Sql")),
            new ServicesSampleDataSqlMappersEFModule(),
            new ServicesSampleDataSqlMappersEFClientsSqlServerModule()
        });
    }

    #endregion Public methods
}
