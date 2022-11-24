// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.InternalDomain;

/// <summary>
/// Конфигурация типа "Внутренний домен" сопоставителя.
/// </summary>
public class MapperInternalDomainTypeConfiguration : MapperTypeConfiguration<MapperInternalDomainTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public MapperInternalDomainTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<MapperInternalDomainTypeEntity> builder)
    {
        var options = TypesOptions.InternalDomain;

        if (options is null)
        {
            throw new NullVariableException<MapperInternalDomainTypeConfiguration>(nameof(options));
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
