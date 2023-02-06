// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.UserInternalPermission;

/// <summary>
/// Конфигурация типа "Внутреннее разрешение пользователя" сопоставителя.
/// </summary>
public class MapperUserInternalPermissionTypeConfiguration : MapperTypeConfiguration<MapperUserInternalPermissionTypeEntity>
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
    public sealed override void Configure(EntityTypeBuilder<MapperUserInternalPermissionTypeEntity> builder)
    {
        var options = TypesOptions.UserInternalPermission;

        if (options is null)
        {
            throw new NullVariableException<MapperUserInternalPermissionTypeConfiguration>(nameof(options));
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

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserInternalPermissionList)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName(options.DbForeignKeyToUser);

        builder.HasOne(x => x.InternalPermission)
            .WithMany(x => x.UserInternalPermissionList)
            .HasForeignKey(x => x.InternalPermissionId)
            .HasConstraintName(options.DbForeignKeyToInternalPermission);
    }

    #endregion Public methods
}
