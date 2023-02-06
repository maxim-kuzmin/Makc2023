// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Exceptions;

/// <summary>
/// Локализованное исключение.
/// Сообщение, передаваемое в это исключение, должно быть переведено на язык,
/// соответствующий текущей культуре приложения.
/// </summary>
public class LocalizedException : Exception
{
    #region Constructors

    /// <inheritdoc/>
    public LocalizedException(string message)
        : base(message)
    {
    }

    #endregion Constructors
}

