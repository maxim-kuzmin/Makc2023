// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.Response.Data;

/// <summary>
/// Данные отклика веб-приложения с деталями.
/// </summary>
public class WebAppResponseDataWithDetails
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
    /// <param name="details">Подробности.</param>
    /// <param name="summary">Резюме.</param>
    public WebAppResponseDataWithDetails(List<NamedValues<string>> details, string summary)
    {
        Details = details;
        Summary = summary;
    }

    #endregion Constructors
}
