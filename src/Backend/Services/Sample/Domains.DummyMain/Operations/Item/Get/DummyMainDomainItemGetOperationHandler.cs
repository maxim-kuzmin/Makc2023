// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Обработчик операции получения элемента в домене "Фиктивное главное".
/// </summary>
public class DummyMainDomainItemGetOperationHandler :
    OperationWithInputAndOutputHandler<
        DummyMainDomainItemGetOperationInput,
        DummyMainDomainItemGetOperationOutput,
        DummyMainDomainItemGetOperationResult>,
    IDummyMainDomainItemGetOperationHandler
{
    #region Fields

    private readonly IDummyMainDomainResource _domainResource;

    private readonly IOperationsResource _operationsResource;    

    #endregion Fields

    #region Properties

    /// <summary>
    /// Список свойств с недействительными значениями во входных данных.
    /// </summary>
    private OperationInputInvalidProperties InvalidInputProperties { get; set; } = null!;

    #endregion Properties

    #region Constructors

    /// <inheritdoc/>
    public DummyMainDomainItemGetOperationHandler(
        IDummyMainDomainResource domainResource,
        IOperationsResource operationsResource,        
        IOperationResource operationResource,
        ILogger<DummyMainDomainItemGetOperationHandler> logger,
        IOptionsMonitor<SetupOptionsOfCommonCore> setupOptionsOfCommonCore)
        : base(
            domainResource.GetItemGetOperationName(),
            operationResource,
            logger,
            setupOptionsOfCommonCore)
    {     
        _operationsResource = operationsResource;
        _domainResource = domainResource;

        FunctionToTransformOperationInput = TransformOperationInput;
        FunctionToTransformOperationOutput = TransformOperationOutput;
        FunctionToTransformOperationResult = TransformOperationResult;
    }

    #endregion Constructors

    #region Private methods

    private DummyMainDomainItemGetOperationInput TransformOperationInput(DummyMainDomainItemGetOperationInput source)
    {
        source.Normalize();

        InvalidInputProperties = source.GetInvalidProperties(_domainResource, _operationsResource);

        if (InvalidInputProperties.Any())
        {
            var propertyNames = InvalidInputProperties.GetPropertyNames();

            throw new LocalizedException(OperationResource.GetErrorMessageForInvalidInput(propertyNames));
        }

        return source;
    }

    private DummyMainDomainItemGetOperationOutput TransformOperationOutput(DummyMainDomainItemGetOperationOutput source)
    {
        source.Item ??= new();

        return source;
    }

    private DummyMainDomainItemGetOperationResult TransformOperationResult(DummyMainDomainItemGetOperationResult source)
    {
        InvalidInputProperties.CopyToNamedValuesList(source.InvalidInputProperties);

        return source;
    }

    #endregion Private methods
}
