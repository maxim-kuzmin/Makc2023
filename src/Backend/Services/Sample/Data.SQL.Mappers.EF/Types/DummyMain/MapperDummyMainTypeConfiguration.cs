// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyMain;

/// <summary>
/// Конфигурация типа "Фиктивное главное" сопоставителя.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class MapperDummyMainTypeConfiguration<TEntity> : MapperTypeConfiguration<TEntity>
    where TEntity: DummyMainTypeEntity
{
    #region Constructors

    /// <inheritdoc/>
    public MapperDummyMainTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var options = TypesOptions.DummyMain;

        if (options is null)
        {
            throw new NullVariableException<MapperDummyMainTypeConfiguration<TEntity>>(nameof(options));
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

        builder.Property(x => x.DummyOneToManyId)
            .IsRequired()
            .HasColumnName(options.DbColumnForDummyOneToManyId);

        builder.Property(x => x.PropBoolean)
            .IsRequired()
            .HasColumnName(options.DbColumnForPropBoolean);

        builder.Property(x => x.PropBooleanNullable)
            .HasColumnName(options.DbColumnForPropBooleanNullable);

        builder.Property(x => x.PropDate)
            .IsRequired()
            .HasColumnName(options.DbColumnForPropDate);

        builder.Property(x => x.PropDateNullable)
            .HasColumnName(options.DbColumnForPropDateNullable);

        builder.Property(x => x.PropDateTime)
            .IsRequired()
            .HasColumnName(options.DbColumnForPropDateTime);

        builder.Property(x => x.PropDateTimeNullable)
            .HasColumnName(options.DbColumnForPropDateTimeNullable);

        builder.Property(x => x.PropDecimal)
            .IsRequired()
            .HasColumnName(options.DbColumnForPropDecimal);

        builder.Property(x => x.PropDecimalNullable)
            .HasColumnName(options.DbColumnForPropDecimalNullable);

        builder.Property(x => x.PropInt32)
            .IsRequired()
            .HasColumnName(options.DbColumnForPropInt32);

        builder.Property(x => x.PropInt32Nullable)
            .HasColumnName(options.DbColumnForPropInt32Nullable);

        builder.Property(x => x.PropInt64)
            .IsRequired()
            .HasColumnName(options.DbColumnForPropInt64);

        builder.Property(x => x.PropInt64Nullable)
            .HasColumnName(options.DbColumnForPropInt64Nullable);

        builder.Property(x => x.PropString)
            .IsRequired()
            .IsUnicode()
            .HasColumnName(options.DbColumnForPropString);

        builder.Property(x => x.PropStringNullable)
            .IsUnicode()
            .HasColumnName(options.DbColumnForPropStringNullable);

        builder.HasIndex(x => new { x.Name, x.DummyOneToManyId })
            .IsUnique()
            .HasDatabaseName(options.DbUniqueIndexForNameAndDummyOneToManyId);

        builder.HasIndex(x => x.DummyOneToManyId).HasDatabaseName(options.DbIndexForDummyOneToManyId);
    }

    #endregion Public methods
}
