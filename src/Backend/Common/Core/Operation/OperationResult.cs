// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation;

/// <summary>
/// Результат операции.
/// </summary>
public class OperationResult
{
    #region Properties

    /// <summary>
    /// Признак успешности выполнения.
    /// </summary>
    public bool IsOk { get; set; }

    /// <summary>
    /// Сообщения об ошибках.
    /// </summary>
    public HashSet<string> ErrorMessages { get; } = new HashSet<string>();

    /// <summary>
    /// Код операции.
    /// </summary>
    public string OperationCode { get; set; } = OperationHelper.CreateOperationCode();

    /// <summary>
    /// Сообщения об успехах.
    /// </summary>
    public HashSet<string> SuccessMessages { get; } = new HashSet<string>();

    /// <summary>
    /// Сообщения о предупреждениях.
    /// </summary>
    public HashSet<string> WarningMessages { get; } = new HashSet<string>();

    #endregion Properties
}
