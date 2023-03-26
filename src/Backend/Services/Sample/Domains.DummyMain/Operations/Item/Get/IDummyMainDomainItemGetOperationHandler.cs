// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Интерфейс обработчика операции получения элемента в домене "Фиктивное главное".
/// </summary>
public interface IDummyMainDomainItemGetOperationHandler :
    IOperationWithInputAndOutputHandler<
        DummyMainDomainItemGetOperationInput,
        DummyMainDomainItemGetOperationOutput,
        DummyMainDomainItemGetOperationResult>
{
}