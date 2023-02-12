// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.User;

/// <summary>
/// Конфигурация типа "Пользователь" сопоставителя.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class MapperUserTypeConfiguration<TEntity> : MapperTypeConfiguration<TEntity>
    where TEntity : UserTypeEntity
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
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var options = TypesOptions.User;

        if (options is null)
        {
            throw new NullVariableException<MapperUserTypeConfiguration<TEntity>>(nameof(options));
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
