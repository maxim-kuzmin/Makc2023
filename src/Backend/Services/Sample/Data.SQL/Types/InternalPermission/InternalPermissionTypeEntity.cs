// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.InternalPermission;

/// <summary>
/// Сущность типа "Внутреннее разрешение".
/// 
/// Разрешение внутри сервиса на действие во внутреннем домене.
/// </summary>
public class InternalPermissionTypeEntity
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

    /// <summary>
    /// Идентификатор экземпляра сущности "Внутренний домен".
    /// </summary>
    public long InternalDomainId { get;  set; }

    #endregion Properties    
}
