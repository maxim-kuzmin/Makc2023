// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Db;

/// <summary>
/// Контекст базы данных сопоставителя клиента.
/// </summary>
public class ClientMapperDbContext : DbContext
{
    #region Properties        

    /// <summary>
    /// Тип "Фиктивное главное".
    /// </summary>
    public DbSet<ClientMapperDummyMainTypeEntity> DummyMain { get; set; }

    /// <summary>
    /// Тип "Фиктивное отношение многие ко многим".
    /// </summary>
    public DbSet<ClientMapperDummyManyToManyTypeEntity> DummyManyToMany { get; set; }

    /// <summary>
    /// Тип "Фиктивное отношение многие к одному".
    /// </summary>
    public DbSet<ClientMapperDummyManyToManyTypeEntity> DummyManyToOne { get; set; }

    /// <summary>
    /// Тип "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public DbSet<ClientMapperDummyMainDummyManyToManyTypeEntity> DummyMainDummyManyToMany { get; set; }

    /// <summary>
    /// Тип "Фиктивное отношение один ко многим".
    /// </summary>
    public DbSet<ClientMapperDummyOneToManyTypeEntity> DummyOneToMany { get; set; }

    /// <summary>
    /// Тип "Фиктивное дерево".
    /// </summary>
    public DbSet<ClientMapperDummyTreeTypeEntity> DummyTree { get; set; }

    /// <summary>
    /// Тип "Связь фиктивного дерева".
    /// </summary>
    public DbSet<ClientMapperDummyTreeLinkTypeEntity> DummyTreeLink { get; set; }

    /// <summary>
    /// Тип "Внутренний домен".
    /// </summary>
    public DbSet<ClientMapperInternalDomainTypeEntity> InternalDomain { get; set; }

    /// <summary>
    /// Тип "Внутреннее разрешение".
    /// </summary>
    public DbSet<ClientMapperInternalPermissionTypeEntity> InternalPermission { get; set; }

    /// <summary>
    /// Тип "Пользователь".
    /// </summary>
    public DbSet<ClientMapperUserTypeEntity> User { get; set; }

    /// <summary>
    /// Тип "Внутреннее разрешение пользователя".
    /// </summary>
    public DbSet<ClientMapperUserInternalPermissionTypeEntity> UserInternalPermission { get; set; }

    #endregion Properties

    #region Constructors

    /// <inheritdoc/>
    public ClientMapperDbContext(DbContextOptions<ClientMapperDbContext> options)
        : base(options)
    {
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var typesOptions = ClientTypesOptions.Instance;

        modelBuilder.ApplyConfiguration(new ClientMapperDummyMainTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperDummyManyToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperDummyManyToOneTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperDummyMainDummyManyToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperDummyOneToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperDummyTreeTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperDummyTreeLinkTypeConfiguration(typesOptions));        
        modelBuilder.ApplyConfiguration(new ClientMapperInternalDomainTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperInternalPermissionTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperUserTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new ClientMapperUserInternalPermissionTypeConfiguration(typesOptions));
    }

    #endregion Protected methods
}
