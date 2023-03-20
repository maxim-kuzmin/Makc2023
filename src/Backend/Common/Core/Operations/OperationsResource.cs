// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations;

/// <summary>
/// Ресурс операций.
/// </summary>
public class OperationsResource : IOperationsResource
{
    #region Fields

    private readonly IStringLocalizer _localizer;

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="localizer">Локализатор.</param>
    public OperationsResource(IStringLocalizer<OperationsResource> localizer)
    {
        _localizer = localizer;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public string GetOperationInputValidValueForId()
    {
        return _localizer["@@OperationInputValidValueForId"];
    }

    /// <inheritdoc/>
    public string GetOperationInputValidValueForSortField(string asc, string desc)
    {
        return _localizer["@@OperationInputValidValueForSortField", asc, desc];
    }

    #endregion Public methods
}
