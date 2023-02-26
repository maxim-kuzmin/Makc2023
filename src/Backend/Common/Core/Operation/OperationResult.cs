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

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Создать сообщение об ошибке.
    /// </summary>
    /// <returns>Сообщение.</returns>
    public string CreateErrorMessage()
    {
        return ErrorMessages.FromSentencesToText();
    }

    /// <summary>
    /// Загрузить.
    /// </summary>
    /// <param name="operationResult">Результат операции.</param>
    public virtual void Load(OperationResult operationResult)
    {
        ErrorMessages.Clear();

        IsOk = operationResult.IsOk;

        OperationCode = operationResult.OperationCode;

        foreach (string errorMessage in operationResult.ErrorMessages)
        {
            ErrorMessages.Add(errorMessage);
        }
    }

    /// <summary>
    /// Слить.
    /// </summary>
    /// <param name="operationResults">Результаты операции.</param>
    public void Merge(IEnumerable<OperationResult> operationResults)
    {
        bool isOk = true;

        foreach (var operationResult in operationResults)
        {
            isOk = isOk && operationResult.IsOk;

            ErrorMessages.UnionWith(operationResult.ErrorMessages);
        }

        IsOk = isOk;
    }

    #endregion Public methods
}
