// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2023.Core.Exceptions;

namespace Makc2023.Data.Sql.Mappers.EF.Db;

/// <summary>
/// Менеджер базы данных сопоставителя.
/// </summary>
public class MapperDbManager
{
    #region Properties

    private Action<IDbContextTransaction?> ActionToSetTransaction { get; init; }

    private DbContext DbContext { get; init; }

    private Func<IDbContextTransaction?> FunctionToGetTransaction { get; init; }

    private IMapperResource Resource { get; init; }

    /// <summary>
    /// Содержит транзакцию.
    /// </summary>
    public bool HasTransaction => FunctionToGetTransaction.Invoke() is not null;

    #endregion Properties    

    #region Constructors

    /// <summary>
    /// Контсруктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="resource">Ресурс.</param>
    /// <param name="functionToGetTransaction">Функция для получения транзакции.</param>
    /// <param name="actionToSetTransaction">Действие для установки транзакции.</param>
    public MapperDbManager(
        DbContext dbContext,
        IMapperResource resource,
        Func<IDbContextTransaction?> functionToGetTransaction,
        Action<IDbContextTransaction?> actionToSetTransaction)
    {
        DbContext = dbContext;
        Resource = resource;
        FunctionToGetTransaction = functionToGetTransaction;
        ActionToSetTransaction = actionToSetTransaction;
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

        var result = await DbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        ActionToSetTransaction.Invoke(result);

        return result;
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

        var internalTransaction = FunctionToGetTransaction.Invoke();

        if (transaction != internalTransaction)
        {
            throw new LocalizedException(Resource.GetErrorMessageForExternalTransaction(transaction.TransactionId));
        }

        try
        {
            await DbContext.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();

            throw;
        }
        finally
        {
            if (internalTransaction is not null)
            {
                internalTransaction.Dispose();

                ActionToSetTransaction.Invoke(null);
            }
        }
    }

    /// <summary>
    /// Откатить транзакцию.
    /// </summary>
    public void RollbackTransaction()
    {
        var internalTransaction = FunctionToGetTransaction.Invoke();

        try
        {
            internalTransaction?.Rollback();
        }
        finally
        {
            if (internalTransaction is not null)
            {
                internalTransaction.Dispose();

                ActionToSetTransaction.Invoke(null);
            }
        }
    }

    #endregion Public methods
}
