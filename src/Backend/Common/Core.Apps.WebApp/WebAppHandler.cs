// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using NLog;
using NLog.Web;

namespace Makc2023.Backend.Common.Core.Apps.WebApp;

/// <summary>
/// Обработчик веб-приложения.
/// </summary>
public class WebAppHandler : AppHandler
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    public WebAppHandler() : base(LogManagerOfNLog.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger())
    {
    }

    #endregion Constructors
}
