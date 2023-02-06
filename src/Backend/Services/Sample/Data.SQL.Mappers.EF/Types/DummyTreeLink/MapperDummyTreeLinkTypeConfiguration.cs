// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyTreeLink;

/// <summary>
/// Конфигурация типа "Связь фиктивного дерева" сопоставителя.
/// </summary>
public class MapperDummyTreeLinkTypeConfiguration : MapperTypeConfiguration<MapperDummyTreeLinkTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public MapperDummyTreeLinkTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<MapperDummyTreeLinkTypeEntity> builder)
    {
        var options = TypesOptions.DummyTreeLink;

        if (options is null)
        {
            throw new NullVariableException<MapperDummyTreeLinkTypeConfiguration>(nameof(options));
        }

        builder.ToTable(options.DbTable, options.DbSchema);

        builder.HasKey(x => new { x.Id, x.ParentId }).HasName(options.DbPrimaryKey);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName(options.DbColumnForId);

        builder.Property(x => x.ParentId)
            .IsRequired()
            .HasColumnName(options.DbColumnForParentId);

        builder.HasOne(x => x.DummyTreeById)
            .WithMany(x => x.DummyTreeLinkByIdList)
            .HasForeignKey(x => x.Id)
            .HasConstraintName(options.DbForeignKeyToDummyTree);
    }

    #endregion Public methods
}
