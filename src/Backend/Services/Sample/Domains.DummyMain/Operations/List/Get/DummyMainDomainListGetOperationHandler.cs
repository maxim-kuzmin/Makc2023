// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.List.Get;

/// <summary>
/// Обработчик операции получения списка в домене "Фиктивное главное".
/// </summary>
public class DummyMainDomainListGetOperationHandler :
    OperationWithInputAndOutputHandler<
        DummyMainDomainListGetOperationInput,
        DummyMainDomainListGetOperationOutput,
        DummyMainDomainListGetOperationResult>,
    IDummyMainDomainListGetOperationHandler
{
    #region Fields

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
    public DummyMainDomainListGetOperationHandler(
        IDummyMainDomainResource domainResource,
        IOperationsResource operationsResource,        
        IOperationResource operationResource,
        ILogger<DummyMainDomainListGetOperationHandler> logger,
        IOptionsMonitor<SetupOptionsOfCommonCore> setupOptionsOfCommonCore)
        : base(
            domainResource.GetListGetOperationName(),
            operationResource,
            logger,
            setupOptionsOfCommonCore)
    {
        _operationsResource = operationsResource;

        FunctionToTransformOperationInput = TransformOperationInput;
        FunctionToTransformOperationOutput = TransformOperationOutput;
        FunctionToTransformOperationResult = TransformOperationResult;
    }

    #endregion Constructors

    #region Private methods

    private DummyMainDomainListGetOperationInput TransformOperationInput(DummyMainDomainListGetOperationInput source)
    {
        source.Normalize();

        InvalidInputProperties = source.GetInvalidProperties(_operationsResource);

        if (InvalidInputProperties.Any())
        {
            var propertyNames = InvalidInputProperties.GetPropertyNames();

            throw new LocalizedException(OperationResource.GetErrorMessageForInvalidInput(propertyNames));
        }

        return source;
    }

    private DummyMainDomainListGetOperationOutput TransformOperationOutput(DummyMainDomainListGetOperationOutput source)
    {
        source.Items ??= Array.Empty<DummyMainDomainEntity>();

        return source;
    }

    private DummyMainDomainListGetOperationResult TransformOperationResult(DummyMainDomainListGetOperationResult source)
    {
        InvalidInputProperties.CopyToNamedValuesList(source.InvalidInputProperties);

        return source;
    }
    
    #endregion Private methods
}
