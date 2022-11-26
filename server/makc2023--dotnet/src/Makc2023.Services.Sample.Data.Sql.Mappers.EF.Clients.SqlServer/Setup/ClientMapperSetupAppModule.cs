// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Clients.SqlServer.Setup;

/// <summary>
/// Модуль настройки приложения сопоставителя клиента.
/// </summary>
public class ClientMapperSetupAppModule : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContextFactory<ClientMapperDbContext>((x, options) => ClientMapperDbContextFactory.Configure(
            options,
            x.GetRequiredService<IConfiguration>().GetConnectionString(GetConnectionStringName(x)),
            x.GetRequiredService<ILogger<ClientMapperDbContextFactory>>(),
            x.GetRequiredService<IOptionsMonitor<DbSetupOptions>>()));

        services.AddTransient<IMapperDbContextFactory>(x => new ClientMapperDbContextFactory(
            x.GetRequiredService<IDbContextFactory<ClientMapperDbContext>>(),
            x.GetRequiredService<IOptionsMonitor<DbSetupOptions>>()));
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
            {
                typeof(IDbContextFactory<ClientMapperDbContext>),
                typeof(IMapperDbContextFactory),
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