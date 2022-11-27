// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain;

/// <summary>
/// Репозиторий домена.
/// </summary>
public class DomainRepository : MapperRepository<DummyMainEntity>, IDummyMainRepository
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="dbManager">Менеджер базы данных.</param>
    /// <param name="mediator">Посредник.</param>
    public DomainRepository(MapperDbManager dbManager, IMediator mediator)
        : base(dbManager.DbContext, mediator)
    {
    }

    #endregion Constructors
}
