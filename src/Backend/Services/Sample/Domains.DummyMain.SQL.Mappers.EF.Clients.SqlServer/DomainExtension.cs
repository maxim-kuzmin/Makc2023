// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer;

/// <summary>
/// Расширение домена.
/// </summary>
public static class DomainExtension
{
    #region Public methods

    /// <summary>
    /// Применить фильтрацию.
    /// </summary>
    /// <param name="query">Запрос.</param>
    /// <param name="input">Входные данные.</param>
    /// <returns>Запрос с учётом фильтрации.</returns>
    public static IQueryable<ClientMapperDummyMainTypeEntity> ApplyFiltering(
        this IQueryable<ClientMapperDummyMainTypeEntity> query,
        DummyMainItemGetOperationInput input
        )
    {
        if (input.Id > 0)
        {
            query = query.Where(x => x.Id == input.Id);
        }

        if (!string.IsNullOrWhiteSpace(input.Name))
        {
            query = query.Where(x => x.Name == input.Name);
        }

        return query;
    }

    /// <summary>
    /// Применить фильтрацию.
    /// </summary>
    /// <param name="query">Запрос.</param>
    /// <param name="input">Входные данные.</param>
    /// <returns>Запрос с учётом фильтрации.</returns>
    public static IQueryable<ClientMapperDummyMainTypeEntity> ApplyFiltering(
        this IQueryable<ClientMapperDummyMainTypeEntity> query,
        DummyMainListGetOperationInput input
        )
    {
        if (!string.IsNullOrWhiteSpace(input.Name))
        {
            query = query.Where(x => x.Name!.Contains(input.Name));
        }

        if (input.Ids != null && input.Ids.Any())
        {
            if (input.Ids.Length > 1)
            {
                query = query.Where(x => input.Ids.Contains(x.Id));
            }
            else
            {
                long entityId = input.Ids[0];

                query = query.Where(x => x.Id == entityId);
            }
        }

        if (input.DummyOneToManyId > 0)
        {
            query = query.Where(x => x.DummyOneToManyId == input.DummyOneToManyId);
        }

        if (input.DummyOneToManyIds != null && input.DummyOneToManyIds.Any())
        {
            if (input.DummyOneToManyIds.Length > 1)
            {
                query = query.Where(x => input.DummyOneToManyIds.Contains(x.DummyOneToManyId));
            }
            else
            {
                long id = input.DummyOneToManyIds[0];

                query = query.Where(x => x.DummyOneToManyId == id);
            }
        }

        if (!string.IsNullOrWhiteSpace(input.DummyOneToManyName))
        {
            query = query.Where(x => x.DummyOneToMany!.Name!.Contains(input.DummyOneToManyName));
        }

        return query;
    }

    /// <summary>
    /// Применить сортировку.
    /// </summary>
    /// <param name="query">Запрос.</param>
    /// <param name="input">Входные данные.</param>
    /// <returns>Запрос с учётом сортировки.</returns>
    public static IQueryable<ClientMapperDummyMainTypeEntity> ApplySorting(
        this IQueryable<ClientMapperDummyMainTypeEntity> query,
        DummyMainListGetOperationInput input
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
