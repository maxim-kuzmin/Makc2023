// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.App.Setup;

/// <summary>
/// Модуль настройки приложения.
/// </summary>
public class SetupAppModule : AppModule
{
    #region Fields

    private readonly IAppEnvironment _appEnvironment;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="appEnvironment">Окружение приложения.</param>
    public SetupAppModule(IAppEnvironment appEnvironment)
    {
        _appEnvironment = appEnvironment;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(x => _appEnvironment);

        services.AddSingleton(x => new SetupService(
            x.GetRequiredService<IAppEnvironment>(),
            x.GetRequiredService<IRepeatService>(),
            x.GetRequiredService<ISetupServiceOfServiceDataSQL>()
            ));

        services.AddLocalization(x => x.ConfigureLocalization());

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<ModuleOfCommonDomain>()
                .RegisterServicesFromAssemblyContaining<ModuleOfCommonDomainSqlMappersEF>()
                .RegisterServicesFromAssemblyContaining<ModuleOfServiceDomainsDummyMain>();
        });

        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
            {
                typeof(IAppEnvironment),
                typeof(IConfiguration),
                typeof(ILogger),
                typeof(IMediator),
                typeof(IStringLocalizer),
            };
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override IEnumerable<Type> GetImports()
    {
        return new[]
            {
                typeof(DummyMainDomainItemGetOperationRequestHandler),
                typeof(DummyMainDomainListGetOperationRequestHandler),
                typeof(IRepeatService),
                typeof(ISetupServiceOfServiceDataSQL),
            };
    }

    #endregion Protected methods
}
