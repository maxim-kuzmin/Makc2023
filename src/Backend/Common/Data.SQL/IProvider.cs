// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.SQL;

/// <summary>
/// Интерфейс поставщика.
/// </summary>
public interface IProvider
{
    /// <summary>
    /// Создать параметр команды базы данных.
    /// </summary>
    /// <param name="name">Имя параметра.</param>
    /// <param name="value">Значение параметра.</param>
    /// <returns>Параметр команды базы данных.</returns>
    DbParameter CreateDbParameter(string name, object value);

    /// <summary>
    /// Создать команду базы данных.
    /// </summary>
    /// <param name="connection">Подключение к базе данных.</param>
    /// <param name="parameters">Параметры команды.</param>
    /// <returns>Команда базы данных.</returns>
    DbCommand? CreateDbCommand(DbConnection connection, DbParameter[] parameters);

    /// <summary>
    /// Создать подключение к базе данных.
    /// </summary>
    /// <param name="connectionString">Строка подключения к базе данных.</param>
    /// <param name="transformConnectionString">Функция преобразования строки подключения.</param>
    /// <returns>Подключение к базе данных.</returns>        
    DbConnection CreateDbConnection(string connectionString, Func<string, string>? transformConnectionString = null);

    /// <summary>
    /// Создать построитель запроса перезаполнения идентичности.
    /// </summary>
    /// <returns>Построитель команды.</returns>
    IdentityReseedCommandBuilder CreateQueryIdentityReseedBuilder();

    /// <summary>
    /// Создать построитель запроса вычисления дерева.
    /// </summary>
    /// <returns>Построитель команды.</returns>
    TreeCalculateCommandBuilder CreateQueryTreeCalculateBuilder();

    /// <summary>
    /// Создать построитель запроса триггера дерева.
    /// </summary>
    /// <returns>Построитель команды.</returns>
    TreeTriggerCommandBuilder CreateQueryTreeTriggerBuilder();
}