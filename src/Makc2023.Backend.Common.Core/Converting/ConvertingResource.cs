// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Converting;

/// <summary>
/// Ресурс преобразования.
/// </summary>
public class ConvertingResource : IConvertingResource
{
    #region Properties

    private IStringLocalizer<ConvertingResource> Localizer { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public ConvertingResource(IStringLocalizer<ConvertingResource> localizer)
    {
        Localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetFormatForDate()
    {
        return Localizer["@@FormatForDate"];
    }

    #endregion Public methods
}
