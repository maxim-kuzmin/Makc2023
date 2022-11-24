// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.User;

/// <summary>
/// Конфигурация типа "Пользователь" сопоставителя.
/// </summary>
public class MapperUserTypeConfiguration : MapperTypeConfiguration<MapperUserTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public MapperUserTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<MapperUserTypeEntity> builder)
    {
        var options = TypesOptions.User;

        if (options is null)
        {
            throw new NullVariableException<MapperUserTypeConfiguration>(nameof(options));
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

        builder.Property(x => x.Email)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(options.DbMaxLengthForEmail)
            .HasColumnName(options.DbColumnForEmail);

        builder.Property(x => x.IsBlocked)
            .IsRequired()
            .HasColumnName(options.DbColumnForIsBlocked);

        builder.HasIndex(x => x.Name).IsUnique().HasDatabaseName(options.DbUniqueIndexForName);
        builder.HasIndex(x => x.Email).IsUnique().HasDatabaseName(options.DbUniqueIndexForEmail);
    }

    #endregion Public methods
}
