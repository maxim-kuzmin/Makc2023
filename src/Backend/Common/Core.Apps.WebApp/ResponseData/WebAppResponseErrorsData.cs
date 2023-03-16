// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.ResponseData;

/// <summary>
/// Данные об ошибках отклика веб-приложения.
/// </summary>
public class WebAppResponseErrorsData
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
    /// <param name="errorMessages">Сообщения об ошибках.</param>
    public WebAppResponseErrorsData(IEnumerable<string> errorMessages)
    {
        if (errorMessages != null && errorMessages.Any())
        {
            ErrorMessages.AddRange(errorMessages);
        }
    }

    #endregion Constructors
}
