// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.List.Get;

/// <summary>
/// Запрос операции получения списка в домене.
/// </summary>
public class DomainListGetOperationRequest : IRequest<DomainListGetOperationResponse>
{
    #region Properties

    /// <summary>
    /// Входные данные.
    /// </summary>
    public DummyMainItemGetOperationInput Input { get; init; }

    /// <summary>
    /// Код операции.
    /// </summary>
    public string OperationCode { get; init; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="input">Входные данные.</param>
    /// <param name="operationCode">Код операции.</param>
    public DomainListGetOperationRequest(DummyMainItemGetOperationInput input, string operationCode = "")
    {
        Input = input;
        OperationCode = operationCode;
    }

    #endregion Constructors
}
