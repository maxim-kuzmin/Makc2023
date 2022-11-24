// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.DummyOneToMany;

/// <summary>
/// Конфигурация типа "Фиктивное отношение один ко многим" сопоставителя.
/// </summary>
public class MapperDummyOneToManyTypeConfiguration : MapperTypeConfiguration<MapperDummyOneToManyTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public MapperDummyOneToManyTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<MapperDummyOneToManyTypeEntity> builder)
    {
        var options = TypesOptions.DummyOneToMany;

        if (options is null)
        {
            throw new NullVariableException<MapperDummyOneToManyTypeConfiguration>(nameof(options));
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
