// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.Operations.DummyMain.List.Get;

/// <summary>
/// Интерфейс обработчика операции получения списка "Фиктивное главное".
/// </summary>
public interface IDummyMainListGetOperationHandler :
    IOperationWithInputAndOutputHandler<DummyMainListGetOperationInput, DummyMainListGetOperationOutput>
{
}
