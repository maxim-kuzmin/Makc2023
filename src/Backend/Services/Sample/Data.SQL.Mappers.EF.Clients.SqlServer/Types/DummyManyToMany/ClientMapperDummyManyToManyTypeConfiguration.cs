// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyManyToMany;

/// <summary>
/// Конфигурация типа "Фиктивное отношение многие ко многим" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyManyToManyTypeConfiguration :
    MapperDummyManyToManyTypeConfiguration<ClientMapperDummyManyToManyTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperDummyManyToManyTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperDummyManyToManyTypeEntity> builder)
    {
        base.Configure(builder);
    }

    #endregion Public methods
}
