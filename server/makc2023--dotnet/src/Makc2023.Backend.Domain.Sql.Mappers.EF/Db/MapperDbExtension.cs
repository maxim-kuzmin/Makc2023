// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Domain.Sql.Mappers.EF.Db;

/// <summary>
/// Расширение базы данных сопоставителя.
/// </summary>
public static class MapperDbExtension
{
    /// <summary>
    /// Создать единицу работы.
    /// </summary>
    /// <param name="dbContext">Контекст базы данных.</param>
    /// <param name="mediator">Посредник.</param>
    /// <returns>Единица работы.</returns>
    public static IUnitOfWork CreateUnitOfWork(this DbContext dbContext, IMediator mediator)
    {
        return new MapperUnitOfWork(dbContext, mediator);
    }
}
