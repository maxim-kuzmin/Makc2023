// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.List.Get;

/// <summary>
/// Входные данные операции получения списка.
/// </summary>
public abstract class ListGetOperationInput : OperationInput
{
    #region Properties

    /// <summary>
    /// Номер страницы.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Размер страницы.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Поле сортировки.
    /// </summary>
    public string SortField { get; set; } = "";

    /// <summary>
    /// Направление сортировки.
    /// </summary>
    public string SortDirection { get; set; } = "";

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Получить свойства с недействительными значениями.
    /// </summary>
    /// <returns>Свойства с недействительными значениями.</returns>
    public OperationInputInvalidProperties GetInvalidProperties(IOperationsResource operationsResource)
    {
        var result = CreateInvalidProperties();

        if (!string.IsNullOrWhiteSpace(SortDirection)
            &&
            (
                !OperationOptions.SORT_DIRECTION_ASC.Equals(SortDirection, StringComparison.OrdinalIgnoreCase)
                &&
                !OperationOptions.SORT_DIRECTION_DESC.Equals(SortDirection, StringComparison.OrdinalIgnoreCase)
            ))
        {
            var values = result.GetOrAdd(nameof(SortField));

            string value = operationsResource.GetOperationInputValidValueForSortField(
                OperationOptions.SORT_DIRECTION_ASC,
                OperationOptions.SORT_DIRECTION_DESC);

            values.Add(value);
        }

        return result;
    }

    /// <summary>
    /// Нормализовать.
    /// </summary>
    public virtual void Normalize()
    {
        if (PageNumber < 1)
        {
            PageNumber = 1;
        }

        if (PageSize < 1)
        {
            PageSize = 0;
        }
    }

    #endregion Public methods
}
