// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.UserInternalPermission;

/// <summary>
/// Конфигурация типа "Внутреннее разрешение пользователя" сопоставителя клиента.
/// </summary>
public class ClientMapperUserInternalPermissionTypeConfiguration :
    MapperUserInternalPermissionTypeConfiguration<ClientMapperUserInternalPermissionTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperUserInternalPermissionTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperUserInternalPermissionTypeEntity> builder)
    {
        base.Configure(builder);

        var options = TypesOptions.UserInternalPermission;

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
