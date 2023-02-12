// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyTreeLink;

/// <summary>
/// Конфигурация типа "Связь фиктивного дерева" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyTreeLinkTypeConfiguration :
    MapperDummyTreeLinkTypeConfiguration<ClientMapperDummyTreeLinkTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperDummyTreeLinkTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperDummyTreeLinkTypeEntity> builder)
    {
        base.Configure(builder);

        var options = TypesOptions.DummyTreeLink;

        builder.HasOne(x => x.DummyTreeById)
            .WithMany(x => x.DummyTreeLinkByIdList)
            .HasForeignKey(x => x.Id)
            .HasConstraintName(options.DbForeignKeyToDummyTree);
    }

    #endregion Public methods
}
