// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Data.Sql.Mappers.EF.Db;

/// <summary>
/// Расширение базы данных сопоставителя.
/// </summary>
public static class MapperDbExtension
{
    #region Public methods

    /// <summary>
    /// Построить логирование.
    /// </summary>
    /// <param name="builder">Построитель.</param>
    /// <param name="logger">Регистратор.</param>
    /// <param name="logLevel">Уровень логирования.</param>
    public static void BuildLogging(this DbContextOptionsBuilder builder, ILogger logger, LogLevel logLevel)
    {
        builder.LogTo(
            message =>
            {
                switch (logLevel)
                {
                    case LogLevel.Information:
                        logger.LogInformation("{message}", message);
                        break;
                    case LogLevel.Trace:
                        logger.LogTrace("{message}", message);
                        break;
                    case LogLevel.Debug:
                    default:
                        logger.LogDebug("{message}", message);
                        break;
                }
            },
            new[]
            {
                RelationalEventId.CommandExecuted/*,
                RelationalEventId.CommandExecuting*/
            });
    }

    #endregion Public methods
}
