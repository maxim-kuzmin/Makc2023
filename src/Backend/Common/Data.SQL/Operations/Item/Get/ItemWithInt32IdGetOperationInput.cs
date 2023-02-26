// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Operations.Item.Get;

/// <summary>
/// Входные данные операции получения элемента с 32-битным целочисленным идентификатором.
/// </summary>
public class ItemWithInt32IdGetOperationInput : OperationInput
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Нормализовать.
    /// </summary>
    public virtual void Normalize()
    {
        if (Id < 0)
        {
            Id = 0;
        }
    }

    /// <summary>
    /// Получить свойства с недействительными значениями.
    /// </summary>
    /// <returns>Свойства с недействительными значениями.</returns>
    public OperationInputInvalidProperties GetInvalidProperties(IResource resource)
    {
        var result = CreateInvalidProperties();

        if (Id < 1)
        {
            var values = result.GetOrAdd(nameof(Id));

            string value = resource.GetValidValueForId();

            values.Add(value);
        }

        return result;
    }

    #endregion Public methods
}
