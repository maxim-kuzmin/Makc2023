// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql.Clients.SqlServer.Commands.Identity.Reseed;

/// <summary>
/// Построитель команды на повторное заполнение идентичности клиента.
/// </summary>
public class ClientIdentityReseedCommandBuilder : IdentityReseedCommandBuilder
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override string GetResultSql()
    {
        StringBuilder result = new();

        foreach (IdentityReseedCommandInput input in Inputs)
        {
            result.Append($@"
DBCC CHECKIDENT ('{input.Schema}.{input.Table}', RESEED, 0);
");
        }

        return result.ToString();
    }

    #endregion Public methods
}
