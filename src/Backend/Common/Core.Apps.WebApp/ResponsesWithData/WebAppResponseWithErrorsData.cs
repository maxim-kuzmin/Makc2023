﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.ResponsesWithData;

/// <summary>
/// Отклик веб-приложения с данными об ошибках.
/// </summary>
public class WebAppResponseWithErrorsData : WebAppResponseWithData<WebAppResponseErrorsData>
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    /// <param name="data">Данные.</param>
    public WebAppResponseWithErrorsData(string operationCode, WebAppResponseErrorsData data)
        : base(operationCode, data)
    {
    }

    #endregion Constructors
}
