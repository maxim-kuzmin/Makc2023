// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql.Mappers.EF.Db;

/// <summary>
/// Транзакция базы данных сопоставителя.
/// </summary>
public class MapperDbTransaction
{
    #region Properties

    private DbContext DbContext { get; init; }

    /// <summary>
    /// Текущая.
    /// </summary>
    public IDbContextTransaction? Current { get; private set; }

    /// <summary>
    /// Признак активности.
    /// </summary>
    public bool IsActive => Current is not null;

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    public MapperDbTransaction(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Начать асинхронно.
    /// Если возвращается нуль, транзакция уже начата и нужно использовать текущую.
    /// </summary>
    /// <returns>Задача с транзакцией или нулём.</returns>
    public async Task<IDbContextTransaction?> BeginAsync()
    {
        if (IsActive)
        {
            return null;
        }

        Current = await DbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return Current;
    }

    /// <summary>
    /// Зафиксировать асинхронно.
    /// </summary>
    /// <param name="transaction">Транзакция.</param>
    /// <returns>Задача.</returns>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Возникает, если транзакция не совпадает с текущей.
    /// </exception>
    public async Task CommitAsync(IDbContextTransaction transaction)
    {
        if (transaction is null)
        {
            throw new ArgumentNullException(nameof(transaction));
        }

        if (transaction != Current)
        {
            throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
        }

        try
        {
            await DbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch
        {
            Rollback();

            throw;
        }
        finally
        {
            if (Current is not null)
            {
                Current.Dispose();

                Current = null;
            }
        }
    }

    /// <summary>
    /// Откатить транзакцию.
    /// </summary>
    public void Rollback()
    {
        try
        {
            Current?.Rollback();
        }
        finally
        {
            if (Current is not null)
            {
                Current.Dispose();

                Current = null;
            }
        }
    }

    #endregion Public methods
}
