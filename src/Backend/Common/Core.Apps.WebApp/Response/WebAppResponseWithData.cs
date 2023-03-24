// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Response;

/// <summary>
/// Отклик веб-приложения, содержащий данные.
/// </summary>
public class WebAppResponseWithData<TData> : WebAppResponse
{
    #region Properties

    /// <summary>
    /// Сообщения об ошибках.
    /// </summary>
    public TData Data { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    /// <param name="data">Данные.</param>
    public WebAppResponseWithData(string operationCode, TData data)
        : base(operationCode)
    {
        Data = data;
    }

    #endregion Constructors
}
