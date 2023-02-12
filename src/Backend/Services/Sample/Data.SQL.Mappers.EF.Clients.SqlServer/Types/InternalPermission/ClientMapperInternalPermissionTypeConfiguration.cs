// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.InternalPermission;

/// <summary>
/// Конфигурация типа "Внутреннее разрешение" сопоставителя клиента.
/// </summary>
public class ClientMapperInternalPermissionTypeConfiguration :
    MapperInternalPermissionTypeConfiguration<ClientMapperInternalPermissionTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperInternalPermissionTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperInternalPermissionTypeEntity> builder)
    {
        base.Configure(builder);

        var options = TypesOptions.InternalPermission;

        builder.HasOne(x => x.InternalDomain)
            .WithMany(x => x.InternalPermissionList)
            .HasForeignKey(x => x.InternalDomainId)
            .HasConstraintName(options.DbForeignKeyToInternalDomain);
    }

    #endregion Public methods
}
