// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Response.Data;

/// <summary>
/// Данные отклика веб-приложения с сообщениями.
/// </summary>
public class WebAppResponseDataWithMessages
{
    #region Properties

    /// <summary>
    /// Сообщения.
    /// </summary>
    public List<string> Messages { get; } = new();

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="messages">Сообщения.</param>
    public WebAppResponseDataWithMessages(IEnumerable<string> messages)
    {
        if (messages != null && messages.Any())
        {
            Messages.AddRange(messages);
        }
    }

    #endregion Constructors
}
