// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.InternalDomain;

/// <summary>
/// Конфигурация типа "Внутренний домен" сопоставителя клиента.
/// </summary>
public class ClientMapperInternalDomainTypeConfiguration :
    MapperInternalDomainTypeConfiguration<ClientMapperInternalDomainTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperInternalDomainTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperInternalDomainTypeEntity> builder)
    {
        base.Configure(builder);
    }

    #endregion Public methods    
}
