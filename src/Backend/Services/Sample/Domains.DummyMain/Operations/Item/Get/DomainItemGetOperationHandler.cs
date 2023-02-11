// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Обработчик операции получения элемента в домене.
/// </summary>
public class DomainItemGetOperationHandler :
    OperationWithInputAndOutputHandler<DummyMainItemGetOperationInput, DummyMainItemGetOperationOutput>,
    IDummyMainItemGetOperationHandler
{
    #region Fields

    private readonly IDomainResource _domainResource;

    #endregion Fields

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
    }

    #endregion Constructors

    #region Private methods

    private DummyMainItemGetOperationInput TransformOperationInput(DummyMainItemGetOperationInput input)
    {
        input ??= new DummyMainItemGetOperationInput();

        input.Normalize();

        var invalidProperties = input.GetInvalidProperties();

        if (invalidProperties.Any())
        {
            throw new LocalizedException(OperationResource.GetErrorMessageForInvalidInput(invalidProperties));
        }

        return input;
    }

    private DummyMainItemGetOperationOutput TransformOperationOutput(DummyMainItemGetOperationOutput output)
    {
        if (output.IsItemNotFound)
        {
            output.Item = new DummyMainEntity(new DummyMainTypeEntity());

            throw new LocalizedException(_domainResource.GetErrorMessageForEntityNotFound());
        }

        return output;
    }

    #endregion Private methods
}
