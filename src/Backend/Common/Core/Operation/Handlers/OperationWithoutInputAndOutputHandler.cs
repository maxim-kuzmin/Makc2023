// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation.Handlers;

/// <summary>
/// Обработчик операции без входных и выходных данных.
/// </summary>
/// <typeparam name="TOperationResult">Тип результата операции.</typeparam>
public class OperationWithoutInputAndOutputHandler<TOperationResult> :
    OperationHandler,
    IOperationWithoutInputAndOutputHandler<TOperationResult>
    where TOperationResult : OperationResult, new()
{
    #region Properties

    /// <summary>
    /// Функция преобразования результата операции.
    /// </summary>
    protected Func<TOperationResult, TOperationResult>? FunctionToTransformOperationResult { get; set; }

    /// <inheritdoc/>
    public TOperationResult OperationResult { get; private set; } = null!;

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
    public void HandleStart(string operationCode = "")
    {
        OnStart(operationCode);
    }

    /// <inheritdoc/>
    public void HandleSuccess()
    {
        InitOperationResult(true);

        OnSuccess();
    }

    /// <inheritdoc/>
    public void HandleSuccessWithResult(TOperationResult operationResult)
    {
        OperationResult = operationResult;

        OnSuccess();
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override object? GetOperationInput()
    {
        return null;
    }

    /// <inheritdoc/>
    protected sealed override OperationResult GetOperationResult()
    {
        return OperationResult;
    }

    /// <inheritdoc/>
    protected sealed override void InitOperationResult(bool isOk)
    {
        OperationResult = new()
        {
            IsOk = isOk,
        };

        if (!string.IsNullOrWhiteSpace(OperationCode))
        {
            OperationResult.OperationCode = OperationCode;
        }

        if (FunctionToTransformOperationResult != null)
        {
            OperationResult = FunctionToTransformOperationResult.Invoke(OperationResult);
        }
    }

    #endregion Protected methods
}
