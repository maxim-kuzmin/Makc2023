// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Mappers.EF.Db;

/// <summary>
/// Контекст базы данных сопоставителя.
/// </summary>
public abstract class MapperDbContext : DbContext
{
    #region Fields

    private readonly MapperDbTransaction _dbTransaction;

    #endregion Fields

    #region Properties        

    /// <summary>
    /// Тип "Фиктивное главное".
    /// </summary>
    public DbSet<MapperDummyMainTypeEntity> DummyMain { get; set; }

    /// <summary>
    /// Тип "Фиктивное отношение многие ко многим".
    /// </summary>
    public DbSet<MapperDummyManyToManyTypeEntity> DummyManyToMany { get; set; }

    /// <summary>
    /// Тип "Фиктивное отношение многие к одному".
    /// </summary>
    public DbSet<MapperDummyManyToManyTypeEntity> DummyManyToOne { get; set; }

    /// <summary>
    /// Тип "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public DbSet<MapperDummyMainDummyManyToManyTypeEntity> DummyMainDummyManyToMany { get; set; }

    /// <summary>
    /// Тип "Фиктивное отношение один ко многим".
    /// </summary>
    public DbSet<MapperDummyOneToManyTypeEntity> DummyOneToMany { get; set; }

    /// <summary>
    /// Тип "Фиктивное дерево".
    /// </summary>
    public DbSet<MapperDummyTreeTypeEntity> DummyTree { get; set; }

    /// <summary>
    /// Тип "Связь фиктивного дерева".
    /// </summary>
    public DbSet<MapperDummyTreeLinkTypeEntity> DummyTreeLink { get; set; }

    /// <summary>
    /// Тип "Внутренний домен".
    /// </summary>
    public DbSet<MapperInternalDomainTypeEntity> InternalDomain { get; set; }

    /// <summary>
    /// Тип "Внутреннее разрешение".
    /// </summary>
    public DbSet<MapperInternalPermissionTypeEntity> InternalPermission { get; set; }

    /// <summary>
    /// Тип "Пользователь".
    /// </summary>
    public DbSet<MapperUserTypeEntity> User { get; set; }

    /// <summary>
    /// Тип "Внутреннее разрешение пользователя".
    /// </summary>
    public DbSet<MapperUserInternalPermissionTypeEntity> UserInternalPermission { get; set; }

    #endregion Properties

    #region Constructors

    /// <inheritdoc/>
    public MapperDbContext(DbContextOptions options)
        : base(options)
    {
        _dbTransaction = new(this);
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Получить транзакцию базы данных.
    /// </summary>
    /// <returns>Транзакция.</returns>
    public MapperDbTransaction GetDbTransaction() => _dbTransaction;

    #endregion Public methods
}
