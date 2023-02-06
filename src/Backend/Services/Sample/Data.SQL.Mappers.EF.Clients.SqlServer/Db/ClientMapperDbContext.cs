// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Db;

/// <summary>
/// Контекст базы данных сопоставителя клиента.
/// </summary>
public class ClientMapperDbContext : MapperDbContext
{
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

        modelBuilder.ApplyConfiguration(new MapperDummyMainTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperDummyManyToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperDummyManyToOneTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperDummyMainDummyManyToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperDummyOneToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperDummyTreeTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperDummyTreeLinkTypeConfiguration(typesOptions));        
        modelBuilder.ApplyConfiguration(new MapperInternalDomainTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperInternalPermissionTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperUserTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new MapperUserInternalPermissionTypeConfiguration(typesOptions));
    }

    #endregion Protected methods
}
