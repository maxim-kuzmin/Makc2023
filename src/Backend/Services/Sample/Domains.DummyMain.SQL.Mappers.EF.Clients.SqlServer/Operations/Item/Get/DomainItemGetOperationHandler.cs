// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.SQL.Mappers.EF.Clients.SqlServer.Operations.Item.Get;

/// <summary>
/// Обработчик операции получения элемента в домене.
/// </summary>
public class DomainItemGetOperationHandler :
    OperationWithInputAndOutputHandler<
        DummyMainItemGetOperationInput,
        DummyMainItemGetOperationOutput,
        DummyMainItemGetOperationResult>,
    IDummyMainItemGetOperationHandler
{
    #region Fields

    private readonly IDomainResource _domainResource;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Список свойств с недействительными значениями во входных данных.
    /// </summary>
    private List<string> InvalidInputProperties { get; set; } = null!;

    #endregion Properties

    #region Constructors

    /// <inheritdoc/>
    public DomainItemGetOperationHandler(
        IDomainResource domainResource,
        IOperationResource operationResource,
        ILogger<DomainItemGetOperationHandler> logger,
        IOptionsMonitor<SetupOptions> setupOptions)
        : base(
            domainResource.GetItemGetOperationName(),
            operationResource,
            logger,
            setupOptions)
    {
        _domainResource = domainResource;

        FunctionToTransformOperationInput = TransformOperationInput;
        FunctionToTransformOperationOutput = TransformOperationOutput;
        FunctionToTransformOperationResult = TransformOperationResult;
    }

    #endregion Constructors

    #region Private methods

    private DummyMainItemGetOperationInput TransformOperationInput(DummyMainItemGetOperationInput source)
    {
        source.Normalize();

        InvalidInputProperties = source.GetInvalidProperties();

        if (InvalidInputProperties.Any())
        {
            throw new LocalizedException(OperationResource.GetErrorMessageForInvalidInput(InvalidInputProperties));
        }

        return source;
    }

    private DummyMainItemGetOperationOutput TransformOperationOutput(DummyMainItemGetOperationOutput source)
    {
        source.Item ??= new();

        return source;
    }

    private DummyMainItemGetOperationResult TransformOperationResult(DummyMainItemGetOperationResult source)
    {
        source.InvalidInputProperties = InvalidInputProperties;

        return source;
    }

    #endregion Private methods
}
