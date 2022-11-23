// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyManyToMany;

/// <summary>
/// Конфигурация типа "Фиктивное отношение многие ко многим".
/// </summary>
public class DummyManyToManyTypeConfiguration : TypeConfiguration<DummyManyToManyEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public DummyManyToManyTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<DummyManyToManyEntity> builder)
    {
        var options = TypesOptions.DummyManyToMany;

        if (options is null)
        {
            throw new NullVariableException<DummyManyToManyTypeConfiguration>(nameof(options));
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

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(options.DbUniqueIndexForName);
    }

    #endregion Public methods
}
