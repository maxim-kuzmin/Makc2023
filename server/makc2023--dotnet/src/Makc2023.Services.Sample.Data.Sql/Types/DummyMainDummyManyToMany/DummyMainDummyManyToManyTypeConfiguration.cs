// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.DummyMainDummyManyToMany;

/// <summary>
/// Конфигурация типа "Фиктивное отношение многие ко многим фиктивного главного".
/// </summary>
public class DummyMainDummyManyToManyTypeConfiguration : TypeConfiguration<DummyMainDummyManyToManyJoin>
{
    #region Constructors

    /// <inheritdoc/>
    public DummyMainDummyManyToManyTypeConfiguration(TypesOptions typesOptions)
        : base(typesOptions)
    {
    }

    #endregion Constructors

    #region Public methods

    /// <inheritdoc/>
    public sealed override void Configure(EntityTypeBuilder<DummyMainDummyManyToManyJoin> builder)
    {
        var options = TypesOptions.DummyMainDummyManyToMany;

        if (options is null)
        {
            throw new NullVariableException<DummyMainDummyManyToManyTypeConfiguration>(nameof(options));
        }

        builder.ToTable(options.DbTable, options.DbSchema);

        builder.HasKey(x => new { x.DummyMainId, x.DummyManyToManyId }).HasName(options.DbPrimaryKey);

        builder.Property(x => x.DummyMainId)
            .IsRequired()
            .HasColumnName(options.DbColumnForDummyMainId);

        builder.Property(x => x.DummyManyToManyId)
            .IsRequired()
            .HasColumnName(options.DbColumnForDummyManyToManyId);

        builder.HasIndex(x => x.DummyManyToManyId).HasDatabaseName(options.DbIndexForDummyManyToManyId);

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

