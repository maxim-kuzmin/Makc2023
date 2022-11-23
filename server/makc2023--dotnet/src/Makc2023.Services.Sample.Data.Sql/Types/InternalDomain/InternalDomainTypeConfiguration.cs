// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.InternalDomain;

/// <summary>
/// Конфигурация типа "Внутренний домен".
/// </summary>
public class InternalDomainTypeConfiguration : TypeConfiguration<InternalDomainEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public InternalDomainTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<InternalDomainEntity> builder)
    {
        var options = TypesOptions.InternalDomain;

        if (options is null)
        {
            throw new NullVariableException<InternalDomainTypeConfiguration>(nameof(options));
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
