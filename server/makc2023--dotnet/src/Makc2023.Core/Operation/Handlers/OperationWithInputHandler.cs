// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Operation.Handlers;

/// <summary>
/// Обработчик операции с входными данными.
/// </summary>
/// <typeparam name="TOperationInput">Тип входных данных операции.</typeparam>
public class OperationWithInputHandler<TOperationInput> : OperationHandler, IOperationWithInputHandler<TOperationInput>
{
    #region Properties

    /// <summary>
    /// Функция преобразования ввода операции.
    /// </summary>
    protected Func<TOperationInput, TOperationInput>? FunctionToTransformOperationInput { get; set; }

    /// <summary>
    /// Функция получения сообщений об успехах.
    /// </summary>
    protected Func<TOperationInput, IEnumerable<string>>? FunctionToGetSuccessMessages { get; set; }

    /// <summary>
    /// Функция получения сообщений о предупреждениях.
    /// </summary>
    protected Func<TOperationInput, IEnumerable<string>>? FunctionToGetWarningMessages { get; set; }

    /// <inheritdoc/>
    public TOperationInput? OperationInput { get; private set; }

    /// <inheritdoc/>
    public OperationResult? OperationResult { get; private set; }

    #endregion Properties

    #region Constructors

    /// <inheritdoc/>
    public OperationWithInputHandler(
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
    public void OnStart(TOperationInput operationInput, string? operationCode = null)
    {
        OperationInput = FunctionToTransformOperationInput != null
            ? FunctionToTransformOperationInput.Invoke(operationInput)
            : operationInput;

        DoOnStart(operationCode);
    }

    /// <inheritdoc/>
    public void OnSuccess()
    {
        InitOperationResult(true);

        Func<IEnumerable<string>>? functionToGetSuccessMessages = null;

        if (FunctionToGetSuccessMessages != null && OperationInput != null)
        {
            functionToGetSuccessMessages = () => FunctionToGetSuccessMessages.Invoke(OperationInput);
        }

        Func<IEnumerable<string>>? functionToGetWarningMessages = null;

        if (FunctionToGetWarningMessages != null && OperationInput != null)
        {
            functionToGetWarningMessages = () => FunctionToGetWarningMessages.Invoke(OperationInput);
        }

        DoOnSuccess(functionToGetSuccessMessages, functionToGetWarningMessages);
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
        return OperationInput;
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
