// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain.Setup;

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
        };
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override IEnumerable<Type> GetImports()
    {
        return new[]
        {
            typeof(ILogger),
            typeof(IMapperDbContextFactory),
            typeof(IMediator),
            typeof(IStringLocalizer),
            typeof(SetupOptions),
        };
    }

    #endregion Protected methods
}
