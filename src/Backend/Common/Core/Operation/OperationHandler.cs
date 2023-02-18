// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation;

/// <summary>
/// Обработчик операции.
/// </summary>
public abstract class OperationHandler : IOperationHandler
{
    #region Fields

    private readonly string? _operationName;

    #endregion Fields

    #region Properties

    private string Title { get; set; } = "";

    /// <summary>
    /// Ресурс операции.
    /// </summary>
    protected IOperationResource OperationResource { get; }

    /// <summary>
    /// Регистратор.
    /// </summary>
    protected ILogger Logger { get; }

    /// <summary>
    /// Функция получения сообщений об ошибках.
    /// </summary>
    protected Func<Exception, IEnumerable<string>>? FunctionToGetErrorMessages { get; set; }

    /// <summary>
    /// Код операции.
    /// </summary>
    protected string OperationCode { get; private set; } = "";

    /// <summary>
    /// Параметры настройки.
    /// </summary>
    protected IOptionsMonitor<SetupOptions> SetupOptions { get; init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationName">Имя операции.</param>
    /// <param name="operationResource">Ресурс операции.</param>
    /// <param name="logger">Регистратор.</param>
    /// <param name="setupOptions">Параметры настройки.</param>
    public OperationHandler(
        string operationName,
        IOperationResource operationResource,
        ILogger logger,
        IOptionsMonitor<SetupOptions> setupOptions)
    {
        _operationName = operationName;
        OperationResource = operationResource;
        Logger = logger;
        SetupOptions = setupOptions;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public virtual void OnError(Exception? exception = null)
    {
        InitOperationResult(false);

        string errorMessage;

        var operationResult = GetOperationResult();

        var errorMessages = GetErrorMessages(exception);

        if (errorMessages != null && errorMessages.Any())
        {
            operationResult.ErrorMessages.UnionWith(errorMessages);

            errorMessage = errorMessages.FromSentencesToText();
        }
        else
        {
            errorMessage = OperationResource.GetErrorMessageForDefault();

            operationResult.ErrorMessages.Add(errorMessage);
        }

        if (Logger != null)
        {
            string titleForError = OperationResource.GetTitleForError();

            Logger.LogError(
                exception,
                "{Title}{titleForError}. {errorMessage}",
                Title,
                titleForError,
                errorMessage);
        }
    }

    #endregion Public methods

    #region Protected methods


    /// <summary>
    /// Сделать в начале операции.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    protected virtual void DoOnStart(string operationCode)
    {
        OperationCode = string.IsNullOrWhiteSpace(operationCode) ? OperationHelper.CreateOperationCode() : operationCode;

        string titleForOperationCode = OperationResource.GetTitleForOperationCode();

        if (!string.IsNullOrWhiteSpace(operationCode))
        {
            OperationCode = operationCode;
        }

        Title = $"{_operationName}. {titleForOperationCode}: {OperationCode}. ";

        var currentSetupOptions = SetupOptions.CurrentValue;

        if (currentSetupOptions.LogLevel == LogLevel.Debug)
        {
            LogDebugOnStart();
        }
    }

    /// <summary>
    /// Сделать в случае успешного выполнения операции.
    /// </summary>
    protected void DoOnSuccess()
    {
        var currentSetupOptions = SetupOptions.CurrentValue;

        if (currentSetupOptions.LogLevel == LogLevel.Debug)
        {
            LogDebugOnSuccess();
        }
    }

    /// <summary>
    /// Получить входные данные операции.
    /// </summary>
    /// <returns>Входные данные операции.</returns>
    protected abstract object? GetOperationInput();

    /// <summary>
    /// Получить результат выполнения операции.
    /// </summary>
    /// <returns>Результат выполнения операции.</returns>
    protected abstract OperationResult GetOperationResult();

    /// <summary>
    /// Инициализировать результат операции.
    /// </summary>
    /// <param name="isOk">Признак успешности выполнения.</param>
    protected abstract void InitOperationResult(bool isOk);

    #endregion Protected methods

    #region Private methods

    private IEnumerable<string>? GetErrorMessages(Exception? exception)
    {
        IEnumerable<string>? result = null;

        if (FunctionToGetErrorMessages != null && exception != null)
        {
            result = FunctionToGetErrorMessages.Invoke(exception);
        }

        if (result == null || !result.Any())
        {
            string? errorMessage = null;

            if (exception is LocalizedException)
            {
                errorMessage = exception.Message;
            }

            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                result = new[] { errorMessage };
            }
        }

        return result;
    }

    private void LogDebugOnStart()
    {
        if (Logger != null)
        {
            object? operationInput = GetOperationInput();

            string titleForStart = OperationResource.GetTitleForStart();
            string titleForInput = OperationResource.GetTitleForInput();
            string? valueForInput = operationInput?.SerializeToJson(JsonSerializationOptions.ForLogger);

            valueForInput = !string.IsNullOrWhiteSpace(valueForInput)
                ? $". {titleForInput}: {valueForInput}"
                : string.Empty;

            Logger.LogDebug(
                "{Title}{titleForStart}{valueForInput}",
                Title,
                titleForStart,
                valueForInput);
        }
    }

    private void LogDebugOnSuccess()
    {
        if (Logger != null)
        {
            var operationResult = GetOperationResult();

            string titleForSuccess = OperationResource.GetTitleForSuccess();
            string titleForResult = OperationResource.GetTitleForResult();
            string valueForResult = operationResult.SerializeToJson(JsonSerializationOptions.ForLogger);

            Logger.LogDebug(
                "{Title}{titleForSuccess}. {titleForResult}: {valueForResult}",
                Title,
                titleForSuccess,
                titleForResult,
                valueForResult);
        }
    }

    #endregion Private methods
}
