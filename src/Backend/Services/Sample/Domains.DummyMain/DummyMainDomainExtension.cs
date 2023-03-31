// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain;

/// <summary>
/// Расширение домена "Фиктивное главное".
/// </summary>
public static class DummyMainDomainExtension
{
    #region Public methods

    /// <summary>
    /// Применить сортировку.
    /// </summary>
    /// <param name="query">Запрос.</param>
    /// <param name="input">Входные данные.</param>
    /// <returns>Запрос с учётом сортировки.</returns>
    public static IQueryable<ClientMapperDummyMainTypeEntity> ApplySorting(
        this IQueryable<ClientMapperDummyMainTypeEntity> query,
        DummyMainDomainListGetOperationInput input
        )
    {
        if (input.SortField.Equals(nameof(DummyMainTypeEntity.Id), StringComparison.OrdinalIgnoreCase))
        {
            if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_ASC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(x => x.Id);
            }
            else if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_DESC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(x => x.Id);
            }
        }
        else if (input.SortField.Equals(nameof(DummyMainTypeEntity.Name), StringComparison.OrdinalIgnoreCase))
        {
            if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_ASC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(x => x.Name);
            }
            else if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_DESC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(x => x.Name);
            }
        }
        else if (input.SortField.Equals($"{typeof(DummyOneToManyTypeEntity).Name}.{nameof(DummyOneToManyTypeEntity.Name)}", StringComparison.OrdinalIgnoreCase))
        {
            if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_ASC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(x => x.DummyOneToMany != null ? x.DummyOneToMany.Name : "");
            }
            else if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_DESC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(x => x.DummyOneToMany != null ? x.DummyOneToMany.Name : "");
            }
        }
        else if (input.SortField.Equals(nameof(DummyMainTypeEntity.PropDate), StringComparison.OrdinalIgnoreCase))
        {
            if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_ASC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(x => x.PropDate);
            }
            else if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_DESC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(x => x.PropDate);
            }
        }
        else if (input.SortField.Equals(nameof(DummyMainTypeEntity.PropBoolean), StringComparison.OrdinalIgnoreCase))
        {
            if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_ASC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderBy(x => x.PropBoolean);
            }
            else if (input.SortDirection.Equals(OperationOptions.SORT_DIRECTION_DESC, StringComparison.OrdinalIgnoreCase))
            {
                query = query.OrderByDescending(x => x.PropBoolean);
            }
        }

        if (!string.IsNullOrWhiteSpace(input.SortField)
            && !input.SortField.Equals(nameof(DummyMainTypeEntity.Id), StringComparison.OrdinalIgnoreCase))
        {
            query = ((IOrderedQueryable<ClientMapperDummyMainTypeEntity>)query).ThenBy(x => x.Id);
        }

        return query;
    }

    #endregion Public methods
}
