// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Sql.Types.InternalDomain;

/// <summary>
/// Сущность типа "Внутренний домен".
/// 
/// Часть бизнес-логики сервиса, на действия с которой пользователю требуются разрешения.
/// </summary>
public class InternalDomainTypeEntity
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string? Name { get; set; }

    #endregion Properties
}
