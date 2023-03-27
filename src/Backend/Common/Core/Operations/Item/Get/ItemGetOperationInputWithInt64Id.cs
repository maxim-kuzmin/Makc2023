// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Item.Get;

/// <summary>
/// Входные данные операции получения элемента с 64-битным целочисленным идентификатором.
/// </summary>
public class ItemGetOperationInputWithInt64Id : OperationInput
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; set; }

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Нормализовать.
    /// </summary>
    public virtual void Normalize()
    {
        if (Id < 0L)
        {
            Id = 0L;
        }
    }

    /// <summary>
    /// Получить свойства с недействительными значениями.
    /// </summary>
    /// <returns>Свойства с недействительными значениями.</returns>
    public virtual OperationInputInvalidProperties GetInvalidProperties(IOperationsResource operationsResource)
    {
        var result = CreateInvalidProperties();

        if (Id < 1L)
        {
            var values = result.GetOrAdd(nameof(Id));

            string value = operationsResource.GetOperationInputValidValueForId();

            values.Add(value);
        }

        return result;
    }

    #endregion Public methods
}
