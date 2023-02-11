﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation.Handlers;

/// <summary>
/// Обработчик операции с входными и выходными данными.
/// </summary>
/// <typeparam name="TOperationInput">Тип входных данных операции.</typeparam>
/// <typeparam name="TOperationOutput">Тип выходных данных операции.</typeparam>    
public class OperationWithInputAndOutputHandler<TOperationInput, TOperationOutput> : OperationHandler,
    IOperationWithInputAndOutputHandler<TOperationInput, TOperationOutput>
    where TOperationInput : class
    where TOperationOutput : class
{
    #region Properties

    /// <summary>
    /// Функция преобразования ввода операции.
    /// </summary>
    protected Func<TOperationInput, TOperationInput>? FunctionToTransformOperationInput { get; set; }

    /// <summary>
    /// Функция преобразования вывода операции.
    /// </summary>
    protected Func<TOperationOutput, TOperationOutput>? FunctionToTransformOperationOutput { get; set; }

    /// <inheritdoc/>
    public TOperationInput OperationInput { get; private set; } = null!;

    /// <inheritdoc/>
    public OperationResultWithOutput<TOperationOutput> OperationResult { get; private set; } = null!;

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
    public void OnStart(TOperationInput operationInput, string operationCode = "")
    {
        OperationInput = FunctionToTransformOperationInput != null
            ? FunctionToTransformOperationInput.Invoke(operationInput)
            : operationInput;

        DoOnStart(operationCode);
    }

    /// <inheritdoc/>
    public void OnSuccess(TOperationOutput operationOutput)
    {
        InitOperationResult(true);

        if (FunctionToTransformOperationOutput != null)
        {
            operationOutput = FunctionToTransformOperationOutput.Invoke(operationOutput);
        }

        OperationResult.Output = operationOutput;

        DoOnSuccess();
    }

    /// <inheritdoc/>
    public void OnSuccessWithResult(OperationResultWithOutput<TOperationOutput> operationResult)
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
        OperationResult = new OperationResultWithOutput<TOperationOutput>
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
