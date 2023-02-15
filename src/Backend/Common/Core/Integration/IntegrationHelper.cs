// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Integration;

/// <summary>
/// Помощник интеграции.
/// </summary>
public class IntegrationHelper
{
    #region Public methods

    /// <summary>
    /// Создать строковое глобально уникальное значение.
    /// </summary>
    /// <returns>Глобально уникальное значение.</returns>
    public static string CreateStringGlobalUniqueValue()
    {
        return Guid.NewGuid().ToString().ToUpper();
    }

    #endregion Public methods
}
