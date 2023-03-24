// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Response;

/// <summary>
/// Отклик веб-приложения.
/// </summary>
public class WebAppResponse
{
    #region Properties

    /// <summary>
    /// Код операции.
    /// </summary>
    public string OperationCode { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    public WebAppResponse(string operationCode)
    {
        OperationCode = operationCode;
    }

    #endregion Constructors
}
