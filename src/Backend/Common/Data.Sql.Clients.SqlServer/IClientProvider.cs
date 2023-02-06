// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.Sql.Clients.SqlServer;

/// <summary>
///  Интерфейс поставщика клиента.
/// </summary>
public interface IClientProvider : IProvider
{
    #region Methods

    /// <summary>
    /// Получить указатель на файловый поток базы данных SQL Server.
    /// </summary>
    /// <param name="filePath">Путь к файлу.</param>
    /// <param name="access">Уровень доступа.</param>
    /// <param name="txnToken">Токен контекста транзакции.</param>
    /// <returns>Указатель на файловый поток базы данных SQL Server.</returns>
    public SafeFileHandle GetSqlFilestreamHandle(
        string filePath,
        ClientFilestreamAccess access,
        byte[] txnToken
        );

    #endregion Methods
}
