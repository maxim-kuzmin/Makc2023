// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL.Mappers.EF.Db;

/// <summary>
/// Менеджер базы данных сопоставителя.
/// </summary>
/// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
public abstract class MapperDbManager<TDbContext> : IMapperDbManager
    where TDbContext : DbContext
{
    #region Properties

    protected IMapperResource Resource { get; init; }

    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public TDbContext DbContext { get; init; }

    /// <inheritdoc/>
    public bool HasTransaction => Transaction is not null;

    /// <inheritdoc/>
    public bool IsUsed { get; private set; }

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

    /// <inheritdoc/>
    public async Task<IDbContextTransaction?> BeginTransactionAsync()
    {
        if (HasTransaction)
        {
            return null;
        }

        Transaction = await DbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted).ConfigureAwait(false);

        return Transaction;
    }

    /// <inheritdoc/>
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
            await DbContext.SaveChangesAsync().ConfigureAwait(false);

            await Transaction.CommitAsync().ConfigureAwait(false);
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

    /// <inheritdoc/>
    public IExecutionStrategy CreateExecutionStrategy()
    {
        return DbContext.Database.CreateExecutionStrategy();
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

    /// <summary>
    /// Использовать.
    /// </summary>
    public void Use()
    {
        IsUsed = true;
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
