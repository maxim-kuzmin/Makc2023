// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.ConsoleApp;

/// <summary>
/// Обработчик консольного приложения.
/// </summary>
public class ConsoleAppHandler : AppHandler
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    public ConsoleAppHandler() : base(LogManagerOfNLog.GetCurrentClassLogger())
    {
    }

    #endregion Constructors
}
