// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Repeat;

/// <summary>
/// Сервис повторения.
/// </summary>
public class RepeatService : IRepeatService
{
    #region Fields

    private readonly ILogger _logger;

    private readonly IRepeatResource _repeatResource;

    #endregion Fields

    #region Properties

    private Func<Exception, bool> DefaultFunctionToFilterException { get; } = ex => true;

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="logger">Регистратор.</param>
    /// <param name="repeatResource">Ресурс повторения.</param>
    public RepeatService(ILogger<RepeatService> logger, IRepeatResource repeatResource)
    {
        _logger = logger;
        _repeatResource = repeatResource;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public void Execute(
        int retryCount,
        Action actionToExecute,
        Func<Exception, bool>? functionToFilterException = null)
    {
        functionToFilterException ??= DefaultFunctionToFilterException;

        var policy = Policy.Handle(functionToFilterException)
            .WaitAndRetry(
                retryCount: retryCount,
                sleepDurationProvider: GetSleepDuration,
                onRetry: (exception, timeSpan, retryNumber, ctx) => HandleRetry(exception, retryNumber, retryCount));

        policy.Execute(actionToExecute);
    }

    /// <inheritdoc/>
    public Task ExecuteAsync(
        int retryCount,
        Func<Task> functionToExecute,
        Func<Exception, bool>? functionToFilterException = null)
    {
        functionToFilterException ??= DefaultFunctionToFilterException;

        var policy = Policy.Handle(functionToFilterException)
            .WaitAndRetryAsync(
                retryCount: retryCount,
                sleepDurationProvider: GetSleepDuration,
                onRetry: (exception, timeSpan, retryNumber, ctx) => HandleRetry(exception, retryNumber, retryCount));

        return policy.ExecuteAsync(functionToExecute);
    }

    #endregion Public methods

    #region Private methods

    private TimeSpan GetSleepDuration(int retryAttempt)
    {
        return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
    }

    private void HandleRetry(Exception exception, int retryNumber, int retryCount)
    {
        string message = _repeatResource.GetErrorMessageForRetry(exception, retryNumber, retryCount);

        _logger.LogWarning(exception, "{message}", message);
    }

    #endregion Private methods
}
