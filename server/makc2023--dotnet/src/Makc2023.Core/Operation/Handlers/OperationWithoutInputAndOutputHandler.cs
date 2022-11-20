// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Operation.Handlers;

/// <summary>
/// Обработчик операции без входных и выходных данных.
/// </summary>
public class OperationWithoutInputAndOutputHandler : OperationHandler, IOperationWithoutInputAndOutputHandler
{
    #region Properties

    /// <summary>
    /// Функция получения сообщений об успехах.
    /// </summary>
    protected Func<IEnumerable<string>>? FunctionToGetSuccessMessages { get; set; }

    /// <summary>
    /// Функция получения сообщений о предупреждениях.
    /// </summary>
    protected Func<IEnumerable<string>>? FunctionToGetWarningMessages { get; set; }

    /// <inheritdoc/>
    public OperationResult? OperationResult { get; private set; }

    #endregion Properties

    #region Constructors

    /// <inheritdoc/>
    public OperationWithoutInputAndOutputHandler(
        string operationName,
        IOperationResource operationResource,
        ILogger logger,
        IOptionsMonitor<SetupOptions> setupOptions)
        : base(operationName, operationResource, logger, setupOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public void OnStart(string? operationCode = null)
    {
        DoOnStart(operationCode);
    }

    /// <inheritdoc/>
    public void OnSuccess()
    {
        InitOperationResult(true);

        DoOnSuccess(FunctionToGetSuccessMessages, FunctionToGetWarningMessages);
    }

    /// <inheritdoc/>
    public void OnSuccessWithResult(OperationResult operationResult)
    {
        OperationResult = operationResult;

        DoOnSuccess(null, null);
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override object? GetOperationInput()
    {
        return null;
    }

    /// <inheritdoc/>
    protected sealed override OperationResult? GetOperationResult()
    {
        return OperationResult;
    }

    /// <inheritdoc/>
    protected sealed override void InitOperationResult(bool isOk)
    {
        OperationResult = new OperationResult
        {
            IsOk = isOk,
        };

        if (!string.IsNullOrWhiteSpace(OperationCode))
        {
            OperationResult.OperationCode = OperationCode;
        }
    }

    #endregion Protected methods
}
