// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Apps.WebApp.ResponseData;

/// <summary>
/// Данные о деталях отклика веб-приложения.
/// </summary>
public class WebAppResponseDetailsData
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
    public WebAppResponseDetailsData(List<NamedValues<string>> details, string summary)
    {
        Details = details;
        Summary = summary;
    }

    #endregion Constructors
}
