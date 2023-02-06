// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Clients.PostgreSQL;

/// <summary>
/// Поставщик клиента.
/// </summary>
public partial class ClientProvider : IClientProvider
{
    #region Public methods

    /// <inheritdoc/>
    public DbParameter CreateDbParameter(string name, object value)
    {
        return new NpgsqlParameter(name, value);
    }

    /// <inheritdoc/>
    public DbCommand? CreateDbCommand(DbConnection connection, DbParameter[] parameters)
    {
        NpgsqlCommand? result = null;

        if (connection is not NpgsqlConnection cn) return result;

        result = cn.CreateCommand();

        if (parameters == null) return result;

        foreach (DbParameter parameter in parameters)
        {
            NpgsqlParameter par = result.CreateParameter();

            if (!string.IsNullOrEmpty(parameter.ParameterName))
            {
                par.ParameterName = parameter.ParameterName;
            }

            par.Direction = parameter.Direction;
            par.Value = parameter.Value;
            par.DbType = parameter.DbType;

            result.Parameters.Add(par);
        }

        return result;
    }

    /// <inheritdoc/>   
    public DbConnection CreateDbConnection(string connectionString, Func<string, string>? transformConnectionString = null)
    {
        if (transformConnectionString != null)
        {
            connectionString = transformConnectionString(connectionString);
        }

        return new NpgsqlConnection(connectionString);
    }

    /// <inheritdoc/>
    public IdentityReseedCommandBuilder CreateQueryIdentityReseedBuilder()
    {
        return new ClientIdentityReseedCommandBuilder();
    }

    /// <inheritdoc/>
    public TreeCalculateCommandBuilder CreateQueryTreeCalculateBuilder()
    {
        return new ClientTreeCalculateCommandBuilder();
    }

    /// <inheritdoc/>
    public TreeTriggerCommandBuilder CreateQueryTreeTriggerBuilder()
    {
        return new ClientTreeTriggerCommandBuilder();
    }

    #endregion Public methods
}
