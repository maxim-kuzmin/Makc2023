// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Data.Sql.Mappers.EF.Db;

/// <summary>
/// Менеджер базы данных сопоставителя.
/// </summary>
/// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
public abstract class MapperDbManager<TDbContext> where TDbContext : DbContext
{
    #region Properties

    private IMapperResource Resource { get; init; }

    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public TDbContext DbContext { get; init; }

    /// <summary>
    /// Содержит транзакцию.
    /// </summary>
    public bool HasTransaction => Transaction is not null;

    /// <summary>
    /// Транзакция.
    /// </summary>
    public IDbContextTransaction? Transaction { get; private set; }

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Контсруктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="resource">Ресурс.</param>
    public MapperDbManager(TDbContext dbContext, IMapperResource resource)
    {
        DbContext = dbContext;
        Resource = resource;
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
        if (HasTransaction)
        {
            return null;
        }

        Transaction = await DbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return Transaction;
    }

    /// <summary>
    /// Зафиксировать транзакцию асинхронно.
    /// </summary>
    /// <param name="transaction">Транзакция.</param>
    /// <returns>Задача.</returns>
    /// <exception cref="ArgumentNullException">
    /// Возникает, если NULL содержится в аргументе, который не должен его содержать.
    /// </exception>
    /// <exception cref="LocalizedException">
    /// Возникает, если транзакция является внешней.
    /// </exception>
    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction is null)
        {
            throw new ArgumentNullException(nameof(transaction));
        }

        if (transaction != Transaction)
        {
            throw new LocalizedException(Resource.GetErrorMessageForExternalTransaction(transaction.TransactionId));
        }

        try
        {
            await DbContext.SaveChangesAsync();

            await Transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();

            throw;
        }
        finally
        {
            EndTransaction();
        }
    }

    /// <summary>
    /// Откатить транзакцию.
    /// </summary>
    public void RollbackTransaction()
    {
        try
        {
            Transaction?.Rollback();
        }
        finally
        {
            EndTransaction();
        }
    }

    #endregion Public methods

    #region Private methods

    private void EndTransaction()
    {
        if (Transaction is not null)
        {
            Transaction.Dispose();

            Transaction = null;
        }
    }

    #endregion Private methods
}
