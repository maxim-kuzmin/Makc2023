// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Data.Sql.Mappers.EF;

/// <summary>
/// Ресурс сопоставителя.
/// </summary>
public class MapperResource : IMapperResource
{
    #region Properties

    private IStringLocalizer<MapperResource> Localizer { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public MapperResource(IStringLocalizer<MapperResource> localizer)
    {
        Localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForExternalTransaction(Guid transactionId)
    {
        return Localizer["@@ErrorMessageForExternalTransaction", transactionId];
    }

    #endregion Public methods
}
