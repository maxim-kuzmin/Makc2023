// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Operation;

/// <summary>
/// Входные данные операции.
/// </summary>
public class OperationInput
{
    #region Public methods

    /// <summary>
    /// Получить список свойств с недействительными значениями.
    /// </summary>
    /// <returns>Список свойств.</returns>
    public virtual List<string> GetInvalidProperties()
    {
        return new List<string>();
    }

    #endregion Public methods
}
