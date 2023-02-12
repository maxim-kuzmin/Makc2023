// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyManyToOne;

/// <summary>
/// Конфигурация типа "Фиктивное отношение многие к одному" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyManyToOneTypeConfiguration :
    MapperDummyManyToOneTypeConfiguration<ClientMapperDummyManyToOneTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperDummyManyToOneTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperDummyManyToOneTypeEntity> builder)
    {
        base.Configure(builder);

        var options = TypesOptions.DummyManyToOne;

        builder.HasOne(x => x.DummyMain)
            .WithMany(x => x.DummyManyToOneList)
            .HasForeignKey(x => x.DummyMainId)
            .HasConstraintName(options.DbForeignKeyToDummyMain);
    }

    #endregion Public methods
}
