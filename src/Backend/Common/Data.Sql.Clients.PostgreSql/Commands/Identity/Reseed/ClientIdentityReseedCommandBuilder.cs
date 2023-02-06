// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.Sql.Clients.PostgreSql.Commands.Identity.Reseed;

/// <summary>
/// Построитель команды на повторное заполнение идентичности клиента.
/// </summary>
public class ClientIdentityReseedCommandBuilder : IdentityReseedCommandBuilder
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override string GetResultSql()
    {
        var result = new StringBuilder();

        foreach (var input in Inputs)
        {
            foreach (string column in input.Columns)
            {
                result.Append($@"
SELECT setval(pg_get_serial_sequence('""{input.Schema}"".""{input.Table}""', '{column}'), 1);
");
            }
        }

        return result.ToString();
    }

    #endregion Public methods
}
