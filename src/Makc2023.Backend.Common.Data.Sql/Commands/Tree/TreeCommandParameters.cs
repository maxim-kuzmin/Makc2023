// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.Sql.Commands.Tree;

/// <summary>
/// Параметры команды дерева.
/// </summary>
public class TreeCommandParameters
{
    #region Properties

    /// <summary>
    /// Идентификаторы.
    /// </summary>
    public List<DbParameter> Ids { get; private set; } = new();

    #endregion Properties
}
