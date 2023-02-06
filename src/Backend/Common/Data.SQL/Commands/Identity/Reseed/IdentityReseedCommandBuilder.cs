// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Commands.Identity.Reseed;

/// <summary>
/// Построитель команды на повторное заполнение идентичности.
/// </summary>
public abstract class IdentityReseedCommandBuilder
{
    #region Properties

    /// <summary>
    /// Таблицы.
    /// </summary>
    public List<IdentityReseedCommandInput> Inputs { get; private set; }
        = new List<IdentityReseedCommandInput>();

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Получить результирующий SQL.
    /// </summary>
    public abstract string GetResultSql();

    #endregion Public methods
}
