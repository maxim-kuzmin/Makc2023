// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Обработчик операции получения элемента в домене.
/// </summary>
public class DummyMainDomainItemGetOperationHandler :
    OperationWithInputAndOutputHandler<
        DummyMainItemGetOperationInput,
        DummyMainItemGetOperationOutput,
        DummyMainItemGetOperationResult>,
    IDummyMainItemGetOperationHandler
{
    #region Fields

    private readonly IResourceOfCommonDataSQL _resourceOfCommonDataSQL;

    private readonly IResourceOfServiceDomainSQL _resourceOfServiceDomainSQL;

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
        IResourceOfCommonDataSQL resourceOfCommonDataSQL,
        IResourceOfServiceDomainSQL resourceOfServiceDomainSQL,
        IDummyMainDomainResource domainResource,
        IResourceOfCommonCoreOperation resourceOfCommonCoreOperation,
        ILogger<DummyMainDomainItemGetOperationHandler> logger,
        IOptionsMonitor<SetupOptionsOfCommonCore> setupOptionsOfCommonCore)
        : base(
            domainResource.GetItemGetOperationName(),
            resourceOfCommonCoreOperation,
            logger,
            setupOptionsOfCommonCore)
    {     
        _resourceOfCommonDataSQL = resourceOfCommonDataSQL;
        _resourceOfServiceDomainSQL = resourceOfServiceDomainSQL;

        FunctionToTransformOperationInput = TransformOperationInput;
        FunctionToTransformOperationOutput = TransformOperationOutput;
        FunctionToTransformOperationResult = TransformOperationResult;
    }

    #endregion Constructors

    #region Private methods

    private DummyMainItemGetOperationInput TransformOperationInput(DummyMainItemGetOperationInput source)
    {
        source.Normalize();

        InvalidInputProperties = source.GetInvalidProperties(_resourceOfServiceDomainSQL, _resourceOfCommonDataSQL);

        if (InvalidInputProperties.Any())
        {
            var propertyNames = InvalidInputProperties.GetPropertyNames();

            throw new LocalizedException(OperationResource.GetErrorMessageForInvalidInput(propertyNames));
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
        InvalidInputProperties.CopyToNamedValuesList(source.InvalidInputProperties);

        return source;
    }

    #endregion Private methods
}
