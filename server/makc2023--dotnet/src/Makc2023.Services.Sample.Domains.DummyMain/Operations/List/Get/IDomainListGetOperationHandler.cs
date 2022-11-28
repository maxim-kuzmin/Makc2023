// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain.Operations.List.Get;

/// <summary>
/// Интерфейс обработчика операции получения списка в домене.
/// </summary>
public interface IDomainListGetOperationHandler :
    IOperationWithInputAndOutputHandler<DomainListGetOperationInput, DomainListGetOperationOutput>
{
}
