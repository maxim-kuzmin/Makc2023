// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Data.Sql.Clients.SqlServer.Filestream;

/// <summary>
/// Доступ к файловому потоку клиента.
/// </summary>
public enum ClientFilestreamAccess : uint
{
    /// <summary>
    /// Прочитать.
    /// </summary>
    Read,
    /// <summary>
    /// Записать.
    /// </summary>
    Write,
    /// <summary>
    /// Прочитать и записать.
    /// </summary>
    ReadWrite
}
