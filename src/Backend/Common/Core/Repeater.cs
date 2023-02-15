// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core;

/// <summary>
/// Повторитель.
/// </summary>
public class Repeater : IRepeater
{
    #region Fields

    private readonly ILogger _logger;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="logger">Регистратор.</param>
    public Repeater(ILogger<Repeater> logger)
    {
        _logger = logger;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public void Execute<TException>(int retryCount, Action actionToExecute)
        where TException : Exception
    {
        var retry = Policy.Handle<TException>()
            .WaitAndRetry(
                retryCount: retryCount,
                sleepDurationProvider: GetSleepDuration,
                onRetry: (exception, timeSpan, retry, ctx) => HandleRetry(retryCount, exception, retry));

        retry.Execute(actionToExecute);
    }

    /// <inheritdoc/>
    public Task ExecuteAsync<TException>(int retryCount, Func<Task> functionToExecute)
        where TException : Exception
    {
        var policy = Policy.Handle<TException>()
            .WaitAndRetryAsync(
                retryCount: retryCount,
                sleepDurationProvider: GetSleepDuration,
                onRetry: (exception, timeSpan, retry, ctx) => HandleRetry(retryCount, exception, retry));

        return policy.ExecuteAsync(functionToExecute);
    }

    #endregion Public methods

    #region Private methods

    private TimeSpan GetSleepDuration(int retryAttempt)
    {
        return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
    }

    private void HandleRetry(int retryCount, Exception exception, int retry)
    {
        _logger.LogWarning(
            exception,
            "Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retryCount}",
            exception.GetType().Name,
            exception.Message,
            retry,
            retryCount);
    }

    #endregion Private methods
}
