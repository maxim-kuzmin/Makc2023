// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Repeat;

/// <summary>
/// Интерфейс ресурса повторения.
/// </summary>
public class RepeatResource : IRepeatResource
{
    #region Fields

    private readonly IStringLocalizer _localizer;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public RepeatResource(IStringLocalizer<RepeatResource> localizer)
    {
        _localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForRetry(Exception exception, int retryNumber, int retryCount)
    {
        return _localizer["@@ErrorMessageForRetry",
            exception.GetType().Name,
            exception.Message,
            retryNumber,
            retryCount];
    }

    #endregion Public methods
}
