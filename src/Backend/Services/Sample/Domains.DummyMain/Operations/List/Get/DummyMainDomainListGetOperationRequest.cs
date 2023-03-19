// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.List.Get;

/// <summary>
/// Запрос операции получения списка в домене.
/// </summary>
public class DummyMainDomainListGetOperationRequest : IRequest<DummyMainDomainListGetOperationResponse>
{
    #region Properties

    /// <summary>
    /// Входные данные.
    /// </summary>
    public DummyMainListGetOperationInput Input { get; }

    /// <summary>
    /// Код операции.
    /// </summary>
    public string OperationCode { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="input">Входные данные.</param>
    /// <param name="operationCode">Код операции.</param>
    public DummyMainDomainListGetOperationRequest(DummyMainListGetOperationInput input, string operationCode = "")
    {
        Input = input;
        OperationCode = operationCode;
    }

    #endregion Constructors
}
