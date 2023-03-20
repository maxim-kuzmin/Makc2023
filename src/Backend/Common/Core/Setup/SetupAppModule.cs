// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Setup;

/// <summary>
/// Модуль настройки приложения.
/// </summary>
public class SetupAppModule : AppModule
{
    #region Fields

    private readonly IConfigurationSection _configurationSection;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="configurationSection">Раздел конфигурации.</param>
    public SetupAppModule(IConfigurationSection configurationSection)
    {
        _configurationSection = configurationSection;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.Configure<SetupOptions>(_configurationSection);

        services.AddSingleton<IAppResource>(x => new AppResource(
            x.GetRequiredService<IStringLocalizer<AppResource>>()
            ));

        services.AddSingleton<IConvertingResource>(x => new ConvertingResource(
            x.GetRequiredService<IStringLocalizer<ConvertingResource>>()
            ));

        services.AddSingleton<IOperationResource>(x => new OperationResource(
            x.GetRequiredService<IStringLocalizer<OperationResource>>()
            ));

        services.AddSingleton<IOperationsResource>(x => new OperationsResource(
            x.GetRequiredService<IStringLocalizer<OperationsResource>>()
            ));


        services.AddSingleton<IRepeatResource>(x => new RepeatResource(
            x.GetRequiredService<IStringLocalizer<RepeatResource>>()
            ));

        services.AddSingleton<IRepeatService>(x => new RepeatService(
            x.GetRequiredService<ILogger<RepeatService>>(),
            x.GetRequiredService<IRepeatResource>()
            ));
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
            {
                typeof(IAppResource),
                typeof(IConvertingResource),
                typeof(IOperationResource),
                typeof(IOperationsResource),
                typeof(IRepeatResource),
                typeof(IRepeatService),
                typeof(SetupOptions),
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
                typeof(IStringLocalizer),
            };
    }

    #endregion Protected methods
}
