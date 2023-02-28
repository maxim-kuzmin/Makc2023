// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Responses;

/// <summary>
/// Отклик веб-приложения, содержащий ошибки.
/// </summary>
public class WebAppResponseWithErrors : WebAppResponse
{
    #region Properties

    /// <summary>
    /// Сообщения об ошибках.
    /// </summary>
    public List<string> ErrorMessages { get; } = new();

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    /// <param name="errorMessages">Сообщения об ошибках.</param>
    public WebAppResponseWithErrors(string operationCode, IEnumerable<string> errorMessages)
        : base(operationCode)
    {
        if (errorMessages != null && errorMessages.Any())
        {
            ErrorMessages.AddRange(errorMessages);
        }
    }

    #endregion Constructors
}
