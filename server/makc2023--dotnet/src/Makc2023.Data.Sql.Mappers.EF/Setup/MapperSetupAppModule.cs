// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql.Mappers.EF.Setup;

/// <summary>
/// Модуль настройки приложения сопоставителя.
/// </summary>
public class MapperSetupAppModule : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IMapperResource>(x => new MapperResource(
            x.GetRequiredService<IStringLocalizer<MapperResource>>()
            ));
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
            {
                typeof(IMapperResource),
            };
    }

    #endregion Public methods
}
