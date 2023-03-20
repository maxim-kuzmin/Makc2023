// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation.Handlers;

/// <summary>
/// Обработчик операции с входными данными.
/// </summary>
/// <typeparam name="TOperationInput">Тип входных данных операции.</typeparam>
public class OperationWithInputHandler<TOperationInput> :
    OperationHandler,
    IOperationWithInputHandler<TOperationInput>
    where TOperationInput : class, new()
{
    #region Properties

    /// <summary>
    /// Функция преобразования входных данных операции.
    /// </summary>
    protected Func<TOperationInput, TOperationInput>? FunctionToTransformOperationInput { get; set; }

    /// <inheritdoc/>
    public TOperationInput OperationInput { get; private set; } = null!;

    /// <inheritdoc/>
    public OperationResult OperationResult { get; private set; } = null!;

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
    public void HandleStart(TOperationInput operationInput, string operationCode = "")
    {
        OperationInput = operationInput ?? new();

        OnStart(operationCode);

        if (FunctionToTransformOperationInput != null)
        {
            OperationInput = FunctionToTransformOperationInput.Invoke(OperationInput);
        }
    }

    /// <inheritdoc/>
    public void HandleSuccess()
    {
        InitOperationResult(true);

        OnSuccess();
    }

    /// <inheritdoc/>
    public void HandleSuccessWithResult(OperationResult operationResult)
    {
        OperationResult = operationResult;

        OnSuccess();
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
    }

    #endregion Protected methods
}
