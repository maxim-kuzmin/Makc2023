// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Clients.SqlServer.Db;

/// <summary>
/// Контекст базы данных SQL.
/// </summary>
public class ClientDbContext : UnitOfWork
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="options">Настройки.</param>
    /// <param name="mediator">Посредник.</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    public ClientDbContext(DbContextOptions<ClientDbContext> options, IMediator mediator)
        : base(options, mediator)
    {
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var typesOptions = ClientTypesOptions.Instance;

        modelBuilder.ApplyConfiguration(new DummyMainTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new DummyManyToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new DummyMainDummyManyToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new DummyOneToManyTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new DummyTreeTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new DummyTreeLinkTypeConfiguration(typesOptions));
        
        modelBuilder.ApplyConfiguration(new InternalDomainTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new InternalPermissionTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new UserTypeConfiguration(typesOptions));
        modelBuilder.ApplyConfiguration(new UserInternalPermissionTypeConfiguration(typesOptions));
    }

    #endregion Protected methods
}
