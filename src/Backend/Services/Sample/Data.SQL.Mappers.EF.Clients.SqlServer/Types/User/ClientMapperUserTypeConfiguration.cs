// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.User;

/// <summary>
/// Конфигурация типа "Пользователь" сопоставителя клиента.
/// </summary>
public class ClientMapperUserTypeConfiguration :
    MapperUserTypeConfiguration<ClientMapperUserTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperUserTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperUserTypeEntity> builder)
    {
        base.Configure(builder);
    }

    #endregion Public methods
}
