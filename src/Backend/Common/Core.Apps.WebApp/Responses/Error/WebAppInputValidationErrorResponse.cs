// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Responses.Error;

/// <summary>
/// Отклик веб-приложения, содержащий ошибки проверки входных данных.
/// </summary>
public class WebAppInputValidationErrorResponse : WebAppErrorResponse
{
    #region Properties

    /// <summary>
    /// Список свойств с недействительными значениями во входных данных.
    /// </summary>
    public List<NamedValues<string>> InvalidInputProperties { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    /// <param name="errorMessages">Сообщения об ошибках.</param>
    /// <param name="invalidInputProperties">Список свойств с недействительными значениями во входных данных.</param>
    public WebAppInputValidationErrorResponse(
        string operationCode,
        IEnumerable<string> errorMessages,
        List<NamedValues<string>> invalidInputProperties)
        : base(operationCode, errorMessages)
    {
        InvalidInputProperties = invalidInputProperties;
    }

    #endregion Constructors
}
