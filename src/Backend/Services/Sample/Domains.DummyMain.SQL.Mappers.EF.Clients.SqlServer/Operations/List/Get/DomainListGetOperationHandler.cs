// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Operations.List.Get;

/// <summary>
/// Обработчик операции получения списка в домене.
/// </summary>
public class DomainListGetOperationHandler :
    OperationWithInputAndOutputHandler<
        DummyMainListGetOperationInput,
        DummyMainListGetOperationOutput,
        DummyMainListGetOperationResult>,
    IDummyMainListGetOperationHandler
{
    #region Properties

    /// <summary>
    /// Список свойств с недействительными значениями во входных данных.
    /// </summary>
    private List<string> InvalidInputProperties { get; set; } = null!;

    #endregion Properties

    #region Constructors

    /// <inheritdoc/>
    public DomainListGetOperationHandler(
        IDomainResource domainResource,
        IOperationResource operationResource,
        ILogger<DomainListGetOperationHandler> logger,
        IOptionsMonitor<SetupOptions> setupOptions)
        : base(
            domainResource.GetListGetOperationName(),
            operationResource,
            logger,
            setupOptions)
    {
        FunctionToTransformOperationInput = TransformOperationInput;
        FunctionToTransformOperationOutput = TransformOperationOutput;
        FunctionToTransformOperationResult = TransformOperationResult;
    }

    #endregion Constructors

    #region Private methods

    private DummyMainListGetOperationInput TransformOperationInput(DummyMainListGetOperationInput source)
    {
        source.Normalize();

        InvalidInputProperties = source.GetInvalidProperties();

        if (InvalidInputProperties.Any())
        {
            throw new LocalizedException(OperationResource.GetErrorMessageForInvalidInput(InvalidInputProperties));
        }

        return source;
    }

    private DummyMainListGetOperationOutput TransformOperationOutput(DummyMainListGetOperationOutput source)
    {
        source.Items ??= Array.Empty<DummyMainEntity>();

        return source;
    }

    private DummyMainListGetOperationResult TransformOperationResult(DummyMainListGetOperationResult source)
    {
        source.InvalidInputProperties = InvalidInputProperties;

        return source;
    }
    
    #endregion Private methods
}
