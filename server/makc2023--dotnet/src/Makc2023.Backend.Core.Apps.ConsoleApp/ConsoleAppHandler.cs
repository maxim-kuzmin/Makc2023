// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using NLog;

namespace Makc2023.Backend.Core.Apps.ConsoleApp;

/// <summary>
/// Обработчик консольного приложения.
/// </summary>
public class ConsoleAppHandler : AppHandler
{
    #region Protected methods

    /// <inheritdoc/>
    protected sealed override Logger CreateLogger()
    {
        return LogManager.GetCurrentClassLogger();
    }

    #endregion Protected methods
}
