// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Reflection;
using Makc2023.Core.App;
using Microsoft.EntityFrameworkCore.Design;

namespace Makc2023.Services.Sample.Data.Sql.Clients.SqlServer.Db;

/// <summary>
/// Фабрика контекста базы данных SQL.
/// </summary>
public class ClientDbContextFactory : IDesignTimeDbContextFactory<ClientDbContext>
{
    /// <inheritdoc/>
    public ClientDbContext CreateDbContext(string[] args)
    {
        var config = AppHelper.CreateConfiguration();

        var optionsBuilder = new DbContextOptionsBuilder<ClientDbContext>();

        optionsBuilder.UseSqlServer(
            config["ConnectionString"],
            sqlServerOptionsAction: o => o.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));

        return new ClientDbContext(optionsBuilder.Options, null, null);
    }
}
