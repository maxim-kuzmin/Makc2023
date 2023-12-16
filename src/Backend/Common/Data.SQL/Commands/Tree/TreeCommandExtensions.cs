// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Commands.Tree;

/// <summary>
/// Расширения команды дерева.
/// </summary>
public static class TreeCommandExtensions
{
    #region Constants

    /// <summary>
    /// Разделитель пути в дереве.
    /// </summary>
    public const char TREE_PATH_SEPARATOR = '.';

    #endregion Constants

    #region Public methods

    /// <summary>
    /// Преобразовать из 64-битного целого числа в путь в дереве.
    /// </summary>
    /// <param name="value">Значение.</param>
    /// <param name="parentTreePath">Путь родителя в дереве.</param>
    /// <returns>Путь в дереве.</returns>
    public static string FromInt64ToTreePath(this long value, string? parentTreePath)
    {
        return parentTreePath != null ? $"{parentTreePath}{TREE_PATH_SEPARATOR}{value}" : $"{value}";
    }

    /// <summary>
    /// Преобразовать из пути в дереве в массив 64-битных целых чисел.
    /// </summary>
    /// <param name="treePath">Путь в дереве.</param>
    /// <returns>Массив 64-битных целых чисел.</returns>
    public static long[] FromTreePathToInt64Array(this string treePath)
    {
        return treePath.Contains(TREE_PATH_SEPARATOR)
            ? treePath.Split(TREE_PATH_SEPARATOR).Select(long.Parse).ToArray()
            : new[] { long.Parse(treePath) };
    }

    /// <summary>
    /// Преобразовать из пути в дереве в массив 64-битных целых чисел предков.
    /// </summary>
    /// <param name="treePath">Путь в дереве.</param>
    /// <returns>Массив 64-битных целых чисел предков.</returns>
    public static long[] FromTreePathToInt64ArrayOfAncestors(this string treePath)
    {
        long[] allIds = FromTreePathToInt64Array(treePath);

        return allIds.Length > 0
            ? allIds.Take(allIds.Length - 1).ToArray()
            : Array.Empty<long>();
    }

    /// <summary>
    /// Преобразовать из пути в дереве в путь в дереве родителя.
    /// </summary>
    /// <param name="treePath">Путь в дереве.</param>
    /// <returns>Путь в дереве родителя.</returns>
    public static string FromTreePathToParentTreePath(this string treePath)
    {
        long[] ancestors = treePath.FromTreePathToInt64ArrayOfAncestors();

        return ancestors.Length > 0
            ? string.Join(TREE_PATH_SEPARATOR, ancestors)
            : "";
    }

    #endregion Public methods
}
