﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Clients.SqlServer.Db;

/// <summary>
/// Фабрика контекста базы данных клиента.
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

        return new ClientDbContext(optionsBuilder.Options);
    }
}
