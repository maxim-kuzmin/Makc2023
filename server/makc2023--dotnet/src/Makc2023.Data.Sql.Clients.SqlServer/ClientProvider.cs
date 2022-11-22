// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql.Clients.SqlServer
{
    /// <summary>
    /// Поставщик клиента.
    /// </summary>
    public partial class ClientProvider : IClientProvider
    {
        #region Public methods

        /// <inheritdoc/>
        public DbParameter CreateDbParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }

        /// <inheritdoc/>
        public DbCommand? CreateDbCommand(DbConnection connection, DbParameter[] parameters)
        {
            SqlCommand? result = null;

            if (connection is not SqlConnection cn) return result;

            result = cn.CreateCommand();

            if (parameters == null) return result;

            foreach (DbParameter parameter in parameters)
            {
                SqlParameter par = result.CreateParameter();

                string name = parameter.ParameterName;

                if (!string.IsNullOrEmpty(name))
                {
                    if (!name.StartsWith("@"))
                    {
                        name = "@" + name;
                    }

                    par.ParameterName = name;
                }

                par.Direction = parameter.Direction;

                if (parameter.Value is DataTable val)
                {
                    par.SqlDbType = SqlDbType.Structured;
                    par.TypeName = val.TableName;
                    par.SqlValue = val;

                }
                else
                {
                    par.Value = parameter.Value;
                    par.DbType = parameter.DbType;
                }

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

            return new SqlConnection(connectionString);
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

        /// <inheritdoc/>
        public SafeFileHandle GetSqlFilestreamHandle(
            string filePath,
            ClientFilestreamAccess access,
            byte[] txnToken
            )
        {
            return OpenSqlFilestream(
                filePath,
                (uint)access,
                0,
                txnToken,
                (uint)txnToken.Length,
                new Sql64(0)
                );
        }

        #endregion Public methods

        #region Private methods

        [LibraryImport("sqlncli10.dll", EntryPoint = "OpenSqlFilestreamW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
        private static partial SafeFileHandle OpenSqlFilestream(
            string path,
            uint access,
            uint options,
            byte[] txnToken,
            uint txnTokenLength,
            Sql64 allocationSize
            );

        [StructLayout(LayoutKind.Sequential)]
        private struct Sql64
        {
            public long QuadPart;

            public Sql64(long quadPart)
            {
                QuadPart = quadPart;
            }
        }

        #endregion Private methods
    }
}
