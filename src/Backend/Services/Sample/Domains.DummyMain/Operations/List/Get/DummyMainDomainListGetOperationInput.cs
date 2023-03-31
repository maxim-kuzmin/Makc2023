// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Входные данные операции получения списка в домене "Фиктивное главное".
/// </summary>
public class DummyMainDomainListGetOperationInput : ListGetOperationInput
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

    /// <summary>
    /// Создать предикат.
    /// </summary>
    /// <returns>Предикат.</returns>
    public ExpressionStarter<ClientMapperDummyMainTypeEntity> CreatePredicate()
    {
        var result = PredicateBuilder.New<ClientMapperDummyMainTypeEntity>(true);

        if (!string.IsNullOrWhiteSpace(Name))
        {
            result = result.And(x => x.Name!.Contains(Name));
        }

        if (Ids != null && Ids.Any())
        {
            if (Ids.Length > 1)
            {
                result = result.And(x => Ids.Contains(x.Id));
            }
            else
            {
                long entityId = Ids[0];

                result = result.And(x => x.Id == entityId);
            }
        }
        if (DummyOneToManyId > 0)
        {
            result = result.And(x => x.DummyOneToManyId == DummyOneToManyId);
        }

        if (DummyOneToManyIds != null && DummyOneToManyIds.Any())
        {
            if (DummyOneToManyIds.Length > 1)
            {
                result = result.And(x => DummyOneToManyIds.Contains(x.DummyOneToManyId));
            }
            else
            {
                long id = DummyOneToManyIds[0];

                result = result.And(x => x.DummyOneToManyId == id);
            }
        }

        if (!string.IsNullOrWhiteSpace(DummyOneToManyName))
        {
            result = result.And(x => x.DummyOneToMany!.Name!.Contains(DummyOneToManyName));
        }

        return result;
    }

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
