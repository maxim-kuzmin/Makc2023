// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Operation;

/// <summary>
/// Помощник операции.
/// </summary>
public class OperationHelper
{
    #region Public methods

    /// <summary>
    /// Создать код операции.
    /// </summary>
    /// <returns>Код операции.</returns>
    public static string CreateOperationCode()
    {
        return Guid.NewGuid().ToString("N").ToUpper();
    }

    #endregion Public methods
}
