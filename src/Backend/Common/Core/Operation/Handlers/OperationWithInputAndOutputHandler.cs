// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation.Handlers;

/// <summary>
/// Обработчик операции с входными и выходными данными.
/// </summary>
/// <typeparam name="TOperationInput">Тип входных данных операции.</typeparam>
/// <typeparam name="TOperationOutput">Тип выходных данных операции.</typeparam>
/// <typeparam name="TOperationResult">Тип результата операции.</typeparam>
public class OperationWithInputAndOutputHandler<TOperationInput, TOperationOutput, TOperationResult> :
    OperationHandler,
    IOperationWithInputAndOutputHandler<TOperationInput, TOperationOutput, TOperationResult>
    where TOperationInput : class, new()
    where TOperationOutput : class, new()
    where TOperationResult : OperationResultWithOutput<TOperationOutput>, new()
{
    #region Properties

    /// <summary>
    /// Функция преобразования входных данных операции.
    /// </summary>
    protected Func<TOperationInput, TOperationInput>? FunctionToTransformOperationInput { get; set; }

    /// <summary>
    /// Функция преобразования выходных данных операции.
    /// </summary>
    protected Func<TOperationOutput, TOperationOutput>? FunctionToTransformOperationOutput { get; set; }

    /// <summary>
    /// Функция преобразования результата операции.
    /// </summary>
    protected Func<TOperationResult, TOperationResult>? FunctionToTransformOperationResult { get; set; }

    /// <inheritdoc/>
    public TOperationInput OperationInput { get; private set; } = null!;

    /// <inheritdoc/>
    public TOperationResult OperationResult { get; private set; } = null!;

    #endregion Properties

    #region Constructors

    /// <inheritdoc/>
    public OperationWithInputAndOutputHandler(
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
    public sealed override void OnError(Exception? exception = null)
    {
        base.OnError(exception);

        SetOutput(new());
    }

    /// <inheritdoc/>
    public void OnStart(TOperationInput operationInput, string operationCode = "")
    {
        OperationInput = operationInput ?? new();

        DoOnStart(operationCode);

        if (FunctionToTransformOperationInput != null)
        {
            OperationInput = FunctionToTransformOperationInput.Invoke(OperationInput);
        }
    }

    /// <inheritdoc/>
    public void OnSuccess(TOperationOutput operationOutput)
    {
        InitOperationResult(true);

        SetOutput(operationOutput);

        DoOnSuccess();
    }

    /// <inheritdoc/>
    public void OnSuccessWithResult(TOperationResult operationResult)
    {
        OperationResult = operationResult;

        DoOnSuccess();
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override object? GetOperationInput()
    {
        return OperationInput;
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

    #region Private methods

    private void SetOutput(TOperationOutput operationOutput)
    {
        OperationResult.Output = operationOutput;

        if (FunctionToTransformOperationOutput != null)
        {
            OperationResult.Output = FunctionToTransformOperationOutput.Invoke(OperationResult.Output);
        }
    }

    #endregion Private methods
}
