﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyMainDummyManyToMany;

/// <summary>
/// Конфигурация типа "Фиктивное отношение многие ко многим фиктивного главного" сопоставителя.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class MapperDummyMainDummyManyToManyTypeConfiguration<TEntity> : MapperTypeConfiguration<TEntity>
    where TEntity : DummyMainDummyManyToManyTypeEntity
{
    #region Constructors

    /// <inheritdoc/>
    public MapperDummyMainDummyManyToManyTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var options = TypesOptions.DummyMainDummyManyToMany;

        if (options is null)
        {
            throw new NullVariableException<MapperDummyMainDummyManyToManyTypeConfiguration<TEntity>>(nameof(options));
        }

        builder.ToTable(options.DbTable, options.DbSchema);

        builder.HasKey(x => new { x.DummyMainId, x.DummyManyToManyId }).HasName(options.DbPrimaryKey);

        builder.Property(x => x.DummyMainId)
            .IsRequired()
            .HasColumnName(options.DbColumnForDummyMainId);

        builder.Property(x => x.DummyManyToManyId)
            .IsRequired()
            .HasColumnName(options.DbColumnForDummyManyToManyId);

        builder.HasIndex(x => x.DummyManyToManyId).HasDatabaseName(options.DbIndexForDummyManyToManyId);
    }

    #endregion Public methods
}
