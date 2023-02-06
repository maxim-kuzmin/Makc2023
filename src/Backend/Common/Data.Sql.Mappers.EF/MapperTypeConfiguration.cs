// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.Sql.Mappers.EF;

/// <summary>
/// Конфигурация типа.
/// </summary>
/// <typeparam name="TTypesOptions">Тип параметров типов.</typeparam>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public abstract class MapperTypeConfiguration<TTypesOptions, TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    #region Properties

    /// <summary>
    /// Параметры типов.
    /// </summary>
    protected TTypesOptions TypesOptions { get; private set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="typesOptions">Параметры типов.</param>
    public MapperTypeConfiguration(TTypesOptions typesOptions)
    {
        TypesOptions = typesOptions;
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public abstract void Configure(EntityTypeBuilder<TEntity> builder);

    #endregion Public methods
}
