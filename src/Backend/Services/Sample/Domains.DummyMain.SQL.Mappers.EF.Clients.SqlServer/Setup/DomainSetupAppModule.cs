﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Setup;

/// <summary>
/// Модуль настройки приложения домена.
/// </summary>
public class DomainSetupAppModule : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IDomainResource>(x => new DomainResource(
            x.GetRequiredService<IStringLocalizer<DomainResource>>()));

        services.AddTransient<IDummyMainRepository>(x => new DomainRepository(
            x.GetRequiredService<IClientMapperDbContextFactory>(),
            x.GetRequiredService<ClientMapperDbManager>(),
            x.GetRequiredService<IMediator>()
            ));

        services.AddTransient<IDummyMainItemGetOperationHandler>(x => new DomainItemGetOperationHandler(
            x.GetRequiredService<IDomainResource>(),
            x.GetRequiredService<IOperationResource>(),
            x.GetRequiredService<ILogger<DomainItemGetOperationHandler>>(),
            x.GetRequiredService<IOptionsMonitor<SetupOptions>>()));

        services.AddTransient<IDummyMainListGetOperationHandler>(x => new DomainListGetOperationHandler(
            x.GetRequiredService<IDomainResource>(),
            x.GetRequiredService<IOperationResource>(),
            x.GetRequiredService<ILogger<DomainListGetOperationHandler>>(),
            x.GetRequiredService<IOptionsMonitor<SetupOptions>>()));
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
        {
            typeof(IDomainResource),
            typeof(IDummyMainItemGetOperationHandler),
            typeof(IDummyMainListGetOperationHandler),
            typeof(IDummyMainRepository),
        };
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override IEnumerable<Type> GetImports()
    {
        return new[]
        {
            typeof(ClientMapperDbManager),
            typeof(IClientMapperDbContextFactory),
            typeof(ILogger),
            typeof(IMediator),
            typeof(IStringLocalizer),
            typeof(SetupOptions),
        };
    }

    #endregion Protected methods
}
