// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Types.DummyTree;

/// <summary>
/// Конфигурация типа "Фиктивное дерево" сопоставителя.
/// </summary>
public class MapperDummyTreeTypeConfiguration : MapperTypeConfiguration<MapperDummyTreeTypeEntity>
{
    #region Constructors

    /// <inheritdoc/>
    public MapperDummyTreeTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<MapperDummyTreeTypeEntity> builder)
    {
        var options = TypesOptions.DummyTree;

        if (options is null)
        {
            throw new NullVariableException<MapperDummyTreeTypeConfiguration>(nameof(options));
        }

        builder.ToTable(options.DbTable, options.DbSchema);

        builder.HasKey(x => x.Id).HasName(options.DbPrimaryKey);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName(options.DbColumnForId);

        builder.Property(x => x.Name)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(options.DbMaxLengthForName)
            .HasColumnName(options.DbColumnForName);

        builder.Property(x => x.ParentId)
            .HasColumnName(options.DbColumnForParentId);

        builder.Property(x => x.TreeChildCount)
            .IsRequired()
            .HasDefaultValue(0)
            .HasColumnName(options.DbColumnForTreeChildCount);

        builder.Property(x => x.TreeDescendantCount)
            .IsRequired()
            .HasDefaultValue(0)
            .HasColumnName(options.DbColumnForTreeDescendantCount);

        builder.Property(x => x.TreeLevel)
            .IsRequired()
            .HasDefaultValue(0)
            .HasColumnName(options.DbColumnForTreeLevel);

        builder.Property(x => x.TreePath)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(options.DbMaxLengthForTreePath)
            .HasDefaultValue(string.Empty)
            .HasColumnName(options.DbColumnForTreePath);

        builder.Property(x => x.TreePosition)
            .IsRequired()
            .HasDefaultValue(0)
            .HasColumnName(options.DbColumnForTreePosition);

        builder.Property(x => x.TreeSort)
            .IsRequired()
            .IsUnicode(false)
            .HasMaxLength(options.DbMaxLengthForTreeSort)
            .HasDefaultValue(string.Empty)
            .HasColumnName(options.DbColumnForTreeSort);

        builder.HasIndex(x => x.Name).HasDatabaseName(options.DbIndexForName);
        builder.HasIndex(x => x.ParentId).HasDatabaseName(options.DbIndexForParentId);
        builder.HasIndex(x => x.TreeSort).HasDatabaseName(options.DbIndexForTreeSort);

        builder.HasIndex(x => new { x.ParentId, x.Name })
            .IsUnique()
            .HasDatabaseName(options.DbUniqueIndexForParentIdAndName);

        builder.HasOne(x => x.DummyTreeParent)
            .WithMany(x => x.DummyTreeChildList)
            .HasForeignKey(x => x.ParentId)
            .HasConstraintName(options.DbForeignKeyToDummyTreeParent);
    }

    #endregion Public methods
}
