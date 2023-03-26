// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Входные данные операции получения элемента в домене "Фиктивное главное".
/// </summary>
public class DummyMainDomainItemGetOperationInput : ItemWithInt64IdGetOperationInput
{
    #region Properties

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; } = "";

    #endregion Properties

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Normalize()
    {
        base.Normalize();

        if (Id > 0L)
        {
            Name = "";
        }
    }

    /// <inheritdoc/>
    public sealed override OperationInputInvalidProperties GetInvalidProperties(
        IOperationsResource operationsResource)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public OperationInputInvalidProperties GetInvalidProperties(
        IDummyMainDomainResource domainResource,
        IOperationsResource operationsResource)
    {
        var result = base.GetInvalidProperties(operationsResource);

        if (result.Any())
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                var values = result.GetOrAdd(nameof(Name));

                string value = domainResource.GetValidValueForName();

                values.Add(value);
            }
            else
            {
                result.Clear();
            }
        }

        return result;
    }

    #endregion Public methods
}
