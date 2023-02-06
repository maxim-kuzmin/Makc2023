// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Extensions;

/// <summary>
/// Расширение общего типа.
/// </summary>
public static class GenericTypeExtension
{
    #region Public methods

    /// <summary>
    /// Получить имя общего типа.
    /// </summary>
    /// <param name="type">Тип.</param>
    /// <returns>Имя.</returns>
    public static string GetGenericTypeName(this Type type)
    {
        string typeName;

        if (type.IsGenericType)
        {
            string genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());

            typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
        }
        else
        {
            typeName = type.Name;
        }

        return typeName;
    }

    /// <summary>
    /// Получить имя общего типа.
    /// </summary>
    /// <param name="object">Объект.</param>
    /// <returns>Имя.</returns>
    public static string GetGenericTypeName(this object @object)
    {
        return @object.GetType().GetGenericTypeName();
    }

    #endregion Public methods
}
