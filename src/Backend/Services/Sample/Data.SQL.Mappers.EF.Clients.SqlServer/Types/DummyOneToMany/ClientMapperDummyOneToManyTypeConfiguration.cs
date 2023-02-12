// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyOneToMany;

/// <summary>
/// Конфигурация типа "Фиктивное отношение один ко многим" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyOneToManyTypeConfiguration :
    MapperDummyOneToManyTypeConfiguration<ClientMapperDummyOneToManyTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperDummyOneToManyTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperDummyOneToManyTypeEntity> builder)
    {
        base.Configure(builder);
    }

    #endregion Public methods    
}
