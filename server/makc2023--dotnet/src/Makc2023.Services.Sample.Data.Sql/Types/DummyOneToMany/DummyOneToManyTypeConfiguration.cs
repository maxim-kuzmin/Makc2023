// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyOneToMany;

/// <summary>
/// Конфигурация типа "Фиктивное отношение один ко многим".
/// </summary>
public class DummyOneToManyTypeConfiguration : TypeConfiguration<DummyOneToManyEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public DummyOneToManyTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<DummyOneToManyEntity> builder)
    {
        var options = TypesOptions.DummyOneToMany;

        if (options is null)
        {
            throw new NullVariableException<DummyOneToManyTypeConfiguration>(nameof(options));
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
