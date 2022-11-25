﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Clients.SqlServer.Setup;

/// <summary>
/// Модуль настройки приложения клиента.
/// </summary>
public class ClientSetupAppModule : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(x => ClientTypesOptions.Instance);
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
        {
            typeof(TypesOptions)
        };
    }

    #endregion Public methods
}
