// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Microsoft.Extensions.DependencyInjection;

namespace Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Clients.SqlServer.Setup;

/// <summary>
/// Модуль настройки приложения сопоставителя клиента.
/// </summary>
public class ClientMapperSetupAppModule : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ClientMapperDbContext>();

        services.AddDbContextFactory<ClientMapperDbContext>((x, options) => ClientMapperDbContextFactory.Configure(
            options,
            x.GetRequiredService<IConfiguration>().GetConnectionString(GetConnectionStringName(x)),
            x.GetRequiredService<ILogger<ClientMapperDbContextFactory>>(),
            x.GetRequiredService<IOptionsMonitor<DbSetupOptions>>()));

        services.AddScoped<MapperDbContext, ClientMapperDbContext>();

        services.AddScoped(x => new MapperDbManager(
            x.GetRequiredService<MapperDbContext>(),
            x.GetRequiredService<IMapperResource>()
            ));

        services.AddScoped<IMapperDbManager, MapperDbManager>();

        services.AddScoped<IMapperDbContextFactory>(x => new ClientMapperDbContextFactory(
            x.GetRequiredService<IDbContextFactory<ClientMapperDbContext>>(),
            x.GetRequiredService<IOptionsMonitor<DbSetupOptions>>()));
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
            {
                typeof(ClientMapperDbContext),
                typeof(IDbContextFactory<ClientMapperDbContext>),
                typeof(IMapperDbContextFactory),
                typeof(MapperDbContext),
                typeof(MapperDbManager),
            };
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override IEnumerable<Type> GetImports()
    {
        return new[]
            {
                typeof(DbSetupOptions),
                typeof(DbSetupOptionsForSample),
                typeof(IConfiguration),
                typeof(ILogger),
                typeof(IMapperDbManager),
                typeof(IMapperResource),
            };
    }

    #endregion Protected methods

    #region Private methods

    private static string GetConnectionStringName(IServiceProvider serviceProvider)
    {
        string? result = serviceProvider.GetRequiredService<IOptions<DbSetupOptionsForSample>>()
            .Value
            .ConnectionStringName;

        if (string.IsNullOrWhiteSpace(result))
        {
            throw new NullOrWhiteSpaceStringVariableException<DbSetupOptionsForSample>
                (nameof(DbSetupOptionsForSample.ConnectionStringName));
        }

        return result;
    }

    #endregion Private methods
}