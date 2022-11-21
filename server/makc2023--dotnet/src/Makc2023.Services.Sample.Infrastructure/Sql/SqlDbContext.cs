// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Infrastructure.Sql;

/// <summary>
/// Контекст базы данных SQL.
/// </summary>
public class SqlDbContext : UnitOfWork
{
    #region Fields

    private readonly IDefaults _defaults;

    #endregion Fields    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="options">Настройки.</param>
    /// <param name="defaults">Значения по умолчанию.</param>
    /// <param name="mediator">Посредник.</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    public SqlDbContext(DbContextOptions<SqlDbContext> options, IDefaults defaults, IMediator mediator)
        : base(options, mediator)
    {
        _defaults = defaults ?? throw new ArgumentNullException(nameof(defaults));
    }

    #endregion Constructors

    #region Protected methods

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    #endregion Protected methods
}
