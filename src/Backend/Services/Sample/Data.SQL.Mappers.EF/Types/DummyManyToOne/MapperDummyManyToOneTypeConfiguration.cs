// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyManyToOne;

/// <summary>
/// Конфигурация типа "Фиктивное отношение многие к одному" сопоставителя.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class MapperDummyManyToOneTypeConfiguration<TEntity> : MapperTypeConfiguration<TEntity>
    where TEntity : DummyManyToOneTypeEntity
{
    #region Constructors

    /// <inheritdoc/>
    public MapperDummyManyToOneTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var options = TypesOptions.DummyManyToOne;

        if (options is null)
        {
            throw new NullVariableException<MapperDummyManyToOneTypeConfiguration<TEntity>>(nameof(options));
        }

        builder.ToTable(options.DbTable, options.DbSchema);

        builder.HasKey(x => x.Id).HasName(options.DbPrimaryKey);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName(options.DbColumnForId);

        builder.Property(x => x.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(options.DbMaxLengthForName)
            .HasColumnName(options.DbColumnForName);

        builder.Property(x => x.DummyMainId)
            .IsRequired()
            .HasColumnName(options.DbColumnForDummyMainId);

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(options.DbUniqueIndexForName);
        builder.HasIndex(x => x.DummyMainId).HasDatabaseName(options.DbIndexForDummyMainId);
    }

    #endregion Public methods
}
