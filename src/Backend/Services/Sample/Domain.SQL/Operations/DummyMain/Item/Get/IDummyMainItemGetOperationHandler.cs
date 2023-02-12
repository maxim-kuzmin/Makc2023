// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Operations.DummyMain.Item.Get;

/// <summary>
/// Интерфейс обработчика операции получения элемента "Фиктивное главное".
/// </summary>
public interface IDummyMainItemGetOperationHandler :
    IOperationWithInputAndOutputHandler<DummyMainItemGetOperationInput, DummyMainItemGetOperationOutput>
{
}
