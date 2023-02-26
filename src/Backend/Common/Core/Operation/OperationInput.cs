// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation;

/// <summary>
/// Входные данные операции.
/// </summary>
public class OperationInput
{
    #region Public methods

    /// <summary>
    /// Создать свойства с недействительными значениями.
    /// </summary>
    /// <returns>Свойства.</returns>
    public OperationInputInvalidProperties CreateInvalidProperties()
    {
        return new();
    }

    #endregion Public methods
}
