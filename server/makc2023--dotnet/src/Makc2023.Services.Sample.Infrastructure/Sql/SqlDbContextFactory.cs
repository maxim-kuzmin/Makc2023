// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using System.Reflection;
using Makc2023.Core.App;
using Microsoft.EntityFrameworkCore.Design;

namespace Makc2023.Services.Sample.Infrastructure.Sql;

/// <summary>
/// Фабрика контекста базы данных SQL.
/// </summary>
public class SqlDbContextFactory : IDesignTimeDbContextFactory<SqlDbContext>
{
    /// <inheritdoc/>
    public SqlDbContext CreateDbContext(string[] args)
    {
        var config = AppHelper.CreateConfiguration();

        var optionsBuilder = new DbContextOptionsBuilder<SqlDbContext>();

        optionsBuilder.UseSqlServer(
            config["ConnectionString"],
            sqlServerOptionsAction: o => o.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));

        return new SqlDbContext(optionsBuilder.Options, null, null);
    }
}
