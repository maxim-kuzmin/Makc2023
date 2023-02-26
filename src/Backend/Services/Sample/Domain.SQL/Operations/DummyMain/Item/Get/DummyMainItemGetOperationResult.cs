﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Operations.DummyMain.Item.Get;

/// <summary>
/// Результат операции получения элемента "Фиктивное главное".
/// </summary>
public class DummyMainItemGetOperationResult : OperationResultWithOutput<DummyMainItemGetOperationOutput>
{
    #region Properties

    /// <summary>
    /// Список свойств с недействительными значениями во входных данных.
    /// </summary>
    public List<string> InvalidInputProperties { get; set; } = null!;

    #endregion Properties
}
