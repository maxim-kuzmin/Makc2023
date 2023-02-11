// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Operations.Item.Get;

/// <summary>
/// Входные данные операции получения элемента с 32-битным целочисленным идентификатором.
/// </summary>
public class ItemWithInt32IdGetOperationInput : OperationInput
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    #endregion Properties

    #region Public methods

    /// <summary>
    /// Нормализовать.
    /// </summary>
    public virtual void Normalize()
    {
        if (Id < 0)
        {
            Id = 0;
        }
    }

    /// <inheritdoc/>
    public override List<string> GetInvalidProperties()
    {
        var result = base.GetInvalidProperties();

        if (Id < 1)
        {
            result.Add(nameof(Id));
        }

        return result;
    }

    #endregion Public methods
}
