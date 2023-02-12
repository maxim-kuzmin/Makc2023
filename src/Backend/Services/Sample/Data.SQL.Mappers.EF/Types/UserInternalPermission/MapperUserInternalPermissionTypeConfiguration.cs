// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.UserInternalPermission;

/// <summary>
/// Конфигурация типа "Внутреннее разрешение пользователя" сопоставителя.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class MapperUserInternalPermissionTypeConfiguration<TEntity> : MapperTypeConfiguration<TEntity>
    where TEntity : UserInternalPermissionTypeEntity
{
    #region Constructors

    /// <inheritdoc/>
    public MapperUserInternalPermissionTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var options = TypesOptions.UserInternalPermission;

        if (options is null)
        {
            throw new NullVariableException<MapperUserInternalPermissionTypeConfiguration<TEntity>>(nameof(options));
        }

        builder.ToTable(options.DbTable, options.DbSchema);

        builder.HasKey(x => new { x.UserId, x.InternalPermissionId }).HasName(options.DbPrimaryKey);

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasColumnName(options.DbColumnForUserId);

        builder.Property(x => x.InternalPermissionId)
            .IsRequired()
            .HasColumnName(options.DbColumnForInternalPermissionId);

        builder.HasIndex(x => x.InternalPermissionId).HasDatabaseName(options.DbIndexForInternalPermissionId);
    }

    #endregion Public methods
}
