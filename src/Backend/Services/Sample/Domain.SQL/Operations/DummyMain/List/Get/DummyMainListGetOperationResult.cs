// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2023.Backend.Common.Core;

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Operations.DummyMain.List.Get;

/// <summary>
/// Результат операции получения списка "Фиктивное главное".
/// </summary>
public class DummyMainListGetOperationResult : OperationResultWithOutput<DummyMainListGetOperationOutput>
{
    #region Properties

    /// <summary>
    /// Список свойств с недействительными значениями во входных данных.
    /// </summary>
    public List<NamedValues<string>> InvalidInputProperties { get; } = new();

    #endregion Properties
}
