// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.API.Setup;

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
            new CoreModule(configuration.GetRequiredSection($"{root}:Core"))
        });
    }

    #endregion Public methods
}
