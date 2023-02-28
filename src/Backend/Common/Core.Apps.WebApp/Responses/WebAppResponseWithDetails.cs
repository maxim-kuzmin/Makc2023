// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Responses;

/// <summary>
/// Отклик веб-приложения, содержащий подробности.
/// </summary>
public class WebAppResponseWithDetails : WebAppResponse
{
    #region Properties

    /// <summary>
    /// Подробности.
    /// </summary>
    public List<NamedValues<string>> Details { get; }

    /// <summary>
    /// Резюме.
    /// </summary>
    public string Summary { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="operationCode">Код операции.</param>
    /// <param name="details">Подробности.</param>
    /// <param name="summary">Резюме.</param>
    public WebAppResponseWithDetails(
        string operationCode,
        List<NamedValues<string>> details,
        string summary): base(operationCode)
    {
        Details = details;
        Summary = summary;
    }

    #endregion Constructors
}
