// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Responses;

/// <summary>
/// Отклик веб-приложения с деталями.
/// </summary>
public class WebAppResponseWithDetails : WebAppResponseWithData<WebAppResponseDataWithDetails>
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    /// <param name="data">Данные.</param>
    public WebAppResponseWithDetails(string operationCode, WebAppResponseDataWithDetails data)
        : base(operationCode, data)
    {
    }

    #endregion Constructors
}
