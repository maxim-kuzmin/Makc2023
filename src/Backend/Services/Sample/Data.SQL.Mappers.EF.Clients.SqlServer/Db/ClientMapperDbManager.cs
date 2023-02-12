// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Mappers.EF.Clients.SqlServer.Db;

/// <summary>
/// Менеджер базы данных сопоставителя клиента.
/// </summary>
public class ClientMapperDbManager : MapperDbManager<ClientMapperDbContext>
{
    #region Constructors

    /// <summary>
    /// Контсруктор.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="resource">Ресурс.</param>
    public ClientMapperDbManager(ClientMapperDbContext dbContext, IMapperResource resource)
        : base(dbContext, resource)
    {
    }

    #endregion Constructors
}
