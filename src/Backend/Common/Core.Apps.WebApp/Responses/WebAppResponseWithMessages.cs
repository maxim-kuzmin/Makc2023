// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Responses;

/// <summary>
/// Отклик веб-приложения с сообщениями.
/// </summary>
public class WebAppResponseWithMessages : WebAppResponseWithData<WebAppResponseDataWithMessages>
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    /// <param name="data">Данные.</param>
    public WebAppResponseWithMessages(string operationCode, WebAppResponseDataWithMessages data)
        : base(operationCode, data)
    {
    }

    #endregion Constructors
}
