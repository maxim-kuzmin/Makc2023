// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Operations.DummyMain.List.Get;

/// <summary>
/// Входные данные операции получения списка "Фиктивное главное".
/// </summary>
public class DummyMainListGetOperationInput : ListGetOperationInput
{
    #region Properties

    /// <summary>
    /// Идентификаторы.
    /// </summary>
    public long[] Ids { get; set; } = Array.Empty<long>();

    /// <summary>
    /// Строка идентификаторов.
    /// </summary>
    public string IdsString { get; set; } = "";

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Идентификатор экземпляра сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public long DummyOneToManyId { get; set; }

    /// <summary>
    /// Идентификаторы экземпляров сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public long[] DummyOneToManyIds { get; set; } = Array.Empty<long>();

    /// <summary>
    /// Строка идентификаторов экземпляров сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public string DummyOneToManyIdsString { get; set; } = "";

    /// <summary>
    /// Имя экземпляра сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public string DummyOneToManyName { get; set; } = "";

    #endregion Properties

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Normalize()
    {
        base.Normalize();

        if (string.IsNullOrWhiteSpace(SortField))
        {
            SortField = nameof(DummyMainTypeEntity.Id);
        }

        if (string.IsNullOrWhiteSpace(SortDirection))
        {
            SortDirection = OperationOptions.SORT_DIRECTION_DESC;
        }

        if (!string.IsNullOrWhiteSpace(IdsString) && !Ids.Any())
        {
            Ids = IdsString.FromStringToNumericInt64Array();
        }

        if (!string.IsNullOrWhiteSpace(DummyOneToManyIdsString) && !DummyOneToManyIds.Any())
        {
            DummyOneToManyIds = DummyOneToManyIdsString.FromStringToNumericInt64Array();
        }
    }

    #endregion Public methods
}
