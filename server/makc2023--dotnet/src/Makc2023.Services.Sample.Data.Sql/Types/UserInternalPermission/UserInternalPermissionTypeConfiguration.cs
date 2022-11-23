// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.UserInternalPermission;

/// <summary>
/// Конфигурация типа "Внутреннее разрешение пользователя".
/// </summary>
public class UserInternalPermissionTypeConfiguration : TypeConfiguration<UserInternalPermissionJoin>
{
    #region Constructors

    /// <inheritdoc/>
    public UserInternalPermissionTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<UserInternalPermissionJoin> builder)
    {
        var options = TypesOptions.UserInternalPermission;

        if (options is null)
        {
            throw new NullVariableException<UserInternalPermissionTypeConfiguration>(nameof(options));
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

