// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql;

/// <summary>
/// Конфигурация типа.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public abstract class TypeConfiguration<TEntity> : TypeConfiguration<TypesOptions, TEntity>
    where TEntity : class
{
    #region Constructors

    /// <inheritdoc/>
    public TypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors
}
