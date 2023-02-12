// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Operations.Item.Get;

/// <summary>
/// Запрос операции получения элемента в домене.
/// </summary>
public class DomainItemGetOperationRequest : IRequest<DomainItemGetOperationResponse>
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
    public DomainItemGetOperationRequest(DummyMainItemGetOperationInput input, string operationCode = "")
    {
        Input = input;
        OperationCode = operationCode;
    }

    #endregion Constructors
}
