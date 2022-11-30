// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain;

/// <summary>
/// Расширение домена.
/// </summary>
public static class DomainExtension
{
    #region Public methods

    /// <summary>
    /// Применить. Фильтрацию.
    /// </summary>
    /// <param name="query">Запрос.</param>
    /// <param name="input">Входные данные.</param>
    /// <returns>Запрос с учётом фильтрации.</returns>
    public static IQueryable<MapperDummyMainTypeEntity> ApplyFiltering(
        this IQueryable<MapperDummyMainTypeEntity> query,
        DummyMainItemGetOperationInput input
        )
    {
        if (input.Id > 0)
        {
            query = query.Where(x => x.Id == input.Id);
        }

        if (input.Name != null)
        {
            query = query.Where(x => x.Name == input.Name);
        }

        return query;
    }

    /// <summary>
    /// Применить. Фильтрацию.
    /// </summary>
    /// <param name="query">Запрос.</param>
    /// <param name="input">Входные данные.</param>
    /// <returns>Запрос с учётом фильтрации.</returns>
    public static IQueryable<MapperDummyMainTypeEntity> ApplyFiltering(
        this IQueryable<MapperDummyMainTypeEntity> query,
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
    /// Применить. Сортировку.
    /// </summary>
    /// <param name="query">Запрос.</param>
    /// <param name="input">Входные данные.</param>
    /// <returns>Запрос с учётом сортировки.</returns>
    public static IQueryable<MapperDummyMainTypeEntity> ApplySorting(
        this IQueryable<MapperDummyMainTypeEntity> query,
        DummyMainListGetOperationInput input
        )
    {
        if (string.IsNullOrWhiteSpace(input.SortField))
        {
            throw new NullOrWhiteSpaceStringVariableException(typeof(DomainExtension), nameof(input), nameof(input.SortField));
        }

        string sortField = input.SortField.ToLower();

        if (string.IsNullOrWhiteSpace(input.SortDirection))
        {
            throw new NullOrWhiteSpaceStringVariableException(typeof(DomainExtension), nameof(input), nameof(input.SortDirection));
        }

        string sortDirection = input.SortDirection.ToLower();

        string sortFieldForId = nameof(DummyMainTypeEntity.Id).ToLower();
        string sortFieldForName = nameof(DummyMainTypeEntity.Name).ToLower();
        string sortFieldForObjectDummyOneToMany = $"{typeof(DummyOneToManyTypeEntity).Name}.{nameof(DummyOneToManyTypeEntity.Name)}".ToLower();
        string sortFieldForPropDate = nameof(DummyMainTypeEntity.PropDate).ToLower();
        string sortFieldForPropBoolean = nameof(DummyMainTypeEntity.PropBoolean).ToLower();

        if (sortField == sortFieldForId)
        {
            switch (sortDirection)
            {
                case OperationOptions.SORT_DIRECTION_ASC:
                    query = query.OrderBy(x => x.Id);
                    break;
                case OperationOptions.SORT_DIRECTION_DESC:
                    query = query.OrderByDescending(x => x.Id);
                    break;
            }
        }
        else if (sortField == sortFieldForName)
        {
            switch (sortDirection)
            {
                case OperationOptions.SORT_DIRECTION_ASC:
                    query = query.OrderBy(x => x.Name);
                    break;
                case OperationOptions.SORT_DIRECTION_DESC:
                    query = query.OrderByDescending(x => x.Name);
                    break;
            }
        }
        else if (sortField == sortFieldForObjectDummyOneToMany)
        {
            switch (sortDirection)
            {
                case OperationOptions.SORT_DIRECTION_ASC:
                    query = query.OrderBy(x => x.DummyOneToMany!.Name);
                    break;
                case OperationOptions.SORT_DIRECTION_DESC:
                    query = query.OrderByDescending(x => x.DummyOneToMany!.Name);
                    break;
            }
        }
        else if (sortField == sortFieldForPropDate)
        {
            switch (sortDirection)
            {
                case OperationOptions.SORT_DIRECTION_ASC:
                    query = query.OrderBy(x => x.PropDate);
                    break;
                case OperationOptions.SORT_DIRECTION_DESC:
                    query = query.OrderByDescending(x => x.PropDate);
                    break;
            }
        }
        else if (sortField == sortFieldForPropBoolean)
        {
            switch (sortDirection)
            {
                case OperationOptions.SORT_DIRECTION_ASC:
                    query = query.OrderBy(x => x.PropBoolean);
                    break;
                case OperationOptions.SORT_DIRECTION_DESC:
                    query = query.OrderByDescending(x => x.PropBoolean);
                    break;
            }
        }

        if (!string.IsNullOrWhiteSpace(sortField) && sortField != sortFieldForId)
        {
            query = ((IOrderedQueryable<MapperDummyMainTypeEntity>)query).ThenBy(x => x.Id);
        }

        return query;
    }

    #endregion Public methods
}
