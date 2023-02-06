// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.Sql.Clients.PostgreSql.Setup;

/// <summary>
/// Модуль настройки приложения клиента.
/// </summary>
public class ClientSetupAppModule : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IClientProvider>(x => new ClientProvider());
        services.AddSingleton<IProvider>(x => x.GetRequiredService<IClientProvider>());
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
        {
            typeof(IClientProvider),
            typeof(IProvider)
        };
    }

    #endregion Public methods
}