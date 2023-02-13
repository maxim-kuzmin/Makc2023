// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Commands.Tree;

/// <summary>
/// Расширение команды дерева.
/// </summary>
public static class TreeCommandExtension
{
    #region Public methods

    /// <summary>
    /// Преобразовать из 64-битное целого числа в путь в дереве.
    /// </summary>
    /// <param name="value">Значение.</param>
    /// <param name="parentTreePath">Путь родителя в дереве.</param>
    /// <returns>Путь в дереве.</returns>
    public static string FromInt64ToTreePath(this long value, string? parentTreePath)
    {
        return parentTreePath != null ? $"{parentTreePath}.{value}" : $"{value}";
    }

    #endregion Public methods
}
