// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Types.DummyTree;

/// <summary>
/// Конфигурация типа "Фиктивное дерево" сопоставителя клиента.
/// </summary>
public class ClientMapperDummyTreeTypeConfiguration :
    MapperDummyTreeTypeConfiguration<ClientMapperDummyTreeTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public ClientMapperDummyTreeTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<ClientMapperDummyTreeTypeEntity> builder)
    {
        base.Configure(builder);

        var options = TypesOptions.DummyTree;

        builder.HasOne(x => x.DummyTreeParent)
            .WithMany(x => x.DummyTreeChildList)
            .HasForeignKey(x => x.ParentId)
            .HasConstraintName(options.DbForeignKeyToDummyTreeParent);
    }

    #endregion Public methods
}
