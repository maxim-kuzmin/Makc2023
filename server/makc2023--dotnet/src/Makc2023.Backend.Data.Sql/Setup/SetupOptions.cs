// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Data.Sql.Setup;

/// <summary>
/// Параметры настройки.
/// </summary>
public class SetupOptions
{
    #region Properties

    /// <summary>
    /// Таймаут команд базы данных.
    /// </summary>
    public int DbCommandTimeout { get; set; }

    /// <summary>
    /// Уровень логирования.
    /// </summary>
    public LogLevel LogLevel { get; set; }

    #endregion Properties
}