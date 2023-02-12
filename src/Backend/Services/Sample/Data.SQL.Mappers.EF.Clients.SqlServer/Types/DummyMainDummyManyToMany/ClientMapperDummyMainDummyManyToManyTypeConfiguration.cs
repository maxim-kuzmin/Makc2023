// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyMainDummyManyToMany;

/// <summary>
/// Конфигурация типа "Фиктивное отношение многие ко многим фиктивного главного" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyMainDummyManyToManyTypeConfiguration :
    MapperDummyMainDummyManyToManyTypeConfiguration<ClientMapperDummyMainDummyManyToManyTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperDummyMainDummyManyToManyTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperDummyMainDummyManyToManyTypeEntity> builder)
    {
        base.Configure(builder);

        var options = TypesOptions.DummyMainDummyManyToMany;

        builder.HasOne(x => x.DummyMain)
            .WithMany(x => x.DummyMainDummyManyToManyList)
            .HasForeignKey(x => x.DummyMainId)
            .HasConstraintName(options.DbForeignKeyToDummyMain);

        builder.HasOne(x => x.DummyManyToMany)
            .WithMany(x => x.DummyMainDummyManyToManyList)
            .HasForeignKey(x => x.DummyManyToManyId)
            .HasConstraintName(options.DbForeignKeyToDummyManyToMany);
    }

    #endregion Public methods
}
