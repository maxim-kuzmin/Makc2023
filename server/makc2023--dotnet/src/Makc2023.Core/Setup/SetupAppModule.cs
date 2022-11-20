// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Setup;

/// <summary>
/// Модуль настройки приложения.
/// </summary>
public class SetupAppModule : AppModule
{
    #region Properties

    private IConfigurationSection ConfigurationSection { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="configurationSection">Раздел конфигурации.</param>
    public SetupAppModule(IConfigurationSection configurationSection)
    {
        ConfigurationSection = configurationSection;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.Configure<SetupOptions>(ConfigurationSection);

        services.AddSingleton<IAppResource>(x => new AppResource(
            x.GetRequiredService<IStringLocalizer<AppResource>>()
            ));

        services.AddSingleton<IConvertingResource>(x => new ConvertingResource(
            x.GetRequiredService<IStringLocalizer<ConvertingResource>>()
            ));

        services.AddSingleton<IOperationResource>(x => new OperationResource(
            x.GetRequiredService<IStringLocalizer<OperationResource>>()
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
                typeof(SetupOptions),
            };
    }

    #endregion Public methods
}
