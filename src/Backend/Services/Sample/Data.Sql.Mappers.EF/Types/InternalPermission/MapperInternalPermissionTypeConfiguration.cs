// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.Sql.Mappers.EF.Types.InternalPermission;

/// <summary>
/// Конфигурация типа "Внутреннее разрешение" сопоставителя.
/// </summary>
public class MapperInternalPermissionTypeConfiguration : MapperTypeConfiguration<MapperInternalPermissionTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public MapperInternalPermissionTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<MapperInternalPermissionTypeEntity> builder)
    {
        var options = TypesOptions.InternalPermission;

        if (options is null)
        {
            throw new NullVariableException<MapperInternalPermissionTypeConfiguration>(nameof(options));
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

        builder.Property(x => x.InternalDomainId)
            .IsRequired()
            .HasColumnName(options.DbColumnForInternalDomainId);

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(options.DbUniqueIndexForName);
        builder.HasIndex(x => x.InternalDomainId).HasDatabaseName(options.DbIndexForInternalDomainId);

        builder.HasOne(x => x.InternalDomain)
            .WithMany(x => x.InternalPermissionList)
            .HasForeignKey(x => x.InternalDomainId)
            .HasConstraintName(options.DbForeignKeyToInternalDomain);
    }

    #endregion Public methods
}
