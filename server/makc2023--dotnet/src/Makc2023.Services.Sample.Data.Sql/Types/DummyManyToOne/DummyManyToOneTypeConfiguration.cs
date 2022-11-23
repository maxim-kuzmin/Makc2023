// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyManyToOne;

/// <summary>
/// Конфигурация типа "Фиктивное отношение многие к одному".
/// </summary>
public class DummyManyToOneTypeConfiguration : TypeConfiguration<DummyManyToOneEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public DummyManyToOneTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<DummyManyToOneEntity> builder)
    {
        var options = TypesOptions.DummyManyToOne;

        if (options is null)
        {
            throw new NullVariableException<DummyManyToOneTypeConfiguration>(nameof(options));
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

        builder.HasOne(x => x.DummyMain)
            .WithMany(x => x.DummyManyToOneList)
            .HasForeignKey(x => x.DummyMainId)
            .HasConstraintName(options.DbForeignKeyToDummyMain);
    }

    #endregion Public methods
}
