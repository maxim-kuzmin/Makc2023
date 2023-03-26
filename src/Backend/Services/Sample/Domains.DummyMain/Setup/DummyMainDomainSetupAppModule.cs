// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Setup;

/// <summary>
/// Модуль настройки приложения домена.
/// </summary>
public class DummyMainDomainSetupAppModule : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IDummyMainDomainResource>(x => new DummyMainDomainResource(
            x.GetRequiredService<IStringLocalizer<DummyMainDomainResource>>()));

        services.AddTransient<IDummyMainDomainRepository>(x => new DummyMainDomainRepository(
            x.GetRequiredService<IClientMapperDbContextFactory>(),
            x.GetRequiredService<ClientMapperDbManager>(),
            x.GetRequiredService<IMediator>()
            ));

        services.AddTransient<IDummyMainDomainItemGetOperationHandler>(x => new DummyMainDomainItemGetOperationHandler(
            x.GetRequiredService<IDummyMainDomainResource>(),
            x.GetRequiredService<IOperationsResource>(),            
            x.GetRequiredService<IOperationResource>(),
            x.GetRequiredService<ILogger<DummyMainDomainItemGetOperationHandler>>(),
            x.GetRequiredService<IOptionsMonitor<SetupOptionsOfCommonCore>>()));

        services.AddTransient<IDummyMainDomainListGetOperationHandler>(x => new DummyMainDomainListGetOperationHandler(
            x.GetRequiredService<IDummyMainDomainResource>(),
            x.GetRequiredService<IOperationsResource>(),            
            x.GetRequiredService<IOperationResource>(),
            x.GetRequiredService<ILogger<DummyMainDomainListGetOperationHandler>>(),
            x.GetRequiredService<IOptionsMonitor<SetupOptionsOfCommonCore>>()));
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
            {
                typeof(DummyMainDomainItemGetOperationRequestHandler),
                typeof(DummyMainDomainListGetOperationRequestHandler),
                typeof(IDummyMainDomainResource),
                typeof(IDummyMainDomainItemGetOperationHandler),
                typeof(IDummyMainDomainListGetOperationHandler),
                typeof(IDummyMainDomainRepository),
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
                typeof(IOperationResource),
                typeof(IOperationsResource),
                typeof(IStringLocalizer),
                typeof(SetupOptionsOfCommonCore),
            };
    }

    #endregion Protected methods
}
