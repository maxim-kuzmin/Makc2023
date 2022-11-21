// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql;

/// <summary>
/// Единица работы.
/// </summary>
public abstract class UnitOfWork : DbContext, IUnitOfWork
{
    #region Fields

    private readonly IMediator _mediator;

    private IDbContextTransaction? _currentTransaction;

    #endregion Fields    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="options">Настройки.</param>
    /// <param name="mediator">Посредник.</param>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    public UnitOfWork(DbContextOptions options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Начать транзакцию асинхронно.
    /// Если возвращается нуль, транзакция уже начата и нужно использовать текущую.
    /// </summary>
    /// <returns>Задача с транзакцией или нулём.</returns>
    public async Task<IDbContextTransaction?> BeginTransactionAsync()
    {
        if (_currentTransaction is not null)
        {
            return null;
        }

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    /// <summary>
    /// Зафиксировать транзакцию асинхронно.
    /// </summary>
    /// <param name="transaction">Транзакция.</param>
    /// <returns>Задача.</returns>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Возникает, если транзакция не совпадает с текущей.
    /// </exception>
    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction is null)
        {
            throw new ArgumentNullException(nameof(transaction));
        }

        if (transaction != _currentTransaction)
        {
            throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
        }

        try
        {
            await SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();

            throw;
        }
        finally
        {
            if (_currentTransaction is not null)
            {
                _currentTransaction.Dispose();

                _currentTransaction = null;
            }
        }
    }

    /// <summary>
    /// Получить текущую транзакцию.
    /// </summary>
    /// <returns>Транзакция.</returns>
    public IDbContextTransaction? GetCurrentTransaction() => _currentTransaction;

    /// <summary>
    /// Проверить наличие активной транзакции.
    /// </summary>
    /// <returns>Признак наличия активной транзакции.</returns>
    public bool HasActiveTransaction() => _currentTransaction is not null;

    /// <summary>
    /// Откатить транзаакцию.
    /// </summary>
    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction is not null)
            {
                _currentTransaction.Dispose();

                _currentTransaction = null;
            }
        }
    }

    /// <inheritdoc/>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchEventsAsync(this);

        int result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }

    #endregion Public methods
}
