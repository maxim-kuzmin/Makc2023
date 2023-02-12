// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyMain;

/// <summary>
/// Конфигурация типа "Фиктивное главное" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyMainTypeConfiguration : MapperDummyMainTypeConfiguration<ClientMapperDummyMainTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperDummyMainTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperDummyMainTypeEntity> builder)
    {
        base.Configure(builder);

        var options = TypesOptions.DummyMain;

        builder.HasOne(x => x.DummyOneToMany)
            .WithMany(x => x.DummyMainList)
            .HasForeignKey(x => x.DummyOneToManyId)
            .HasConstraintName(options.DbForeignKeyToDummyOneToMany);
    }

    #endregion Public methods
}
