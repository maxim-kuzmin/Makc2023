// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domain.SQL.Operations.DummyMain.Item.Get;

/// <summary>
/// Входные данные операции получения элемента "Фиктивное главное".
/// </summary>
public class DummyMainItemGetOperationInput : ItemWithInt64IdGetOperationInput
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
        IResourceOfCommonDataSQL resourceOfCommonDataSQL)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public OperationInputInvalidProperties GetInvalidProperties(
        IResource resource,
        IResourceOfCommonDataSQL resourceOfCommonDataSQL)
    {
        var result = base.GetInvalidProperties(resourceOfCommonDataSQL);

        if (result.Any())
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                var values = result.GetOrAdd(nameof(Name));

                string value = resource.GetValidValueForName();

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
