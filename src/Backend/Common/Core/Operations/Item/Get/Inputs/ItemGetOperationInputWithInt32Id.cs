﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operations.Item.Get.Inputs;

/// <summary>
/// Входные данные операции получения элемента с 32-битным целочисленным идентификатором.
/// </summary>
public class ItemGetOperationInputWithInt32Id : OperationInput
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
    /// <param name="operationsResource">Ресурс операций.</param>
    /// <returns>Свойства с недействительными значениями.</returns>
    public OperationInputInvalidProperties GetInvalidProperties(IOperationsResource operationsResource)
    {
        var result = CreateInvalidProperties();

        if (Id < 1)
        {
            var values = result.GetOrAdd(nameof(Id));

            string value = operationsResource.GetOperationInputValidValueForId();

            values.Add(value);
        }

        return result;
    }

    #endregion Public methods
}
