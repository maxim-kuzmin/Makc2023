// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Types.DummyTreeLink;

/// <summary>
/// Конфигурация типа "Связь фиктивного дерева" сопоставителя.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class MapperDummyTreeLinkTypeConfiguration<TEntity> : MapperTypeConfiguration<TEntity>
    where TEntity : DummyTreeLinkTypeEntity
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
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        var options = TypesOptions.DummyTreeLink;

        if (options is null)
        {
            throw new NullVariableException<MapperDummyTreeLinkTypeConfiguration<TEntity>>(nameof(options));
        }

        builder.ToTable(options.DbTable, options.DbSchema);

        builder.HasKey(x => new { x.Id, x.ParentId }).HasName(options.DbPrimaryKey);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName(options.DbColumnForId);

        builder.Property(x => x.ParentId)
            .IsRequired()
            .HasColumnName(options.DbColumnForParentId);
    }

    #endregion Public methods
}
