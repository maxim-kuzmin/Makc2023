// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.User;

/// <summary>
/// Сущность типа "Пользователь".
/// 
/// Учётная запись, используемая приложением для проверки прав доступа.
/// </summary>
public class UserTypeEntity
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
    /// Адрес электронной почты.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Признак блокировки.
    /// </summary>
    public bool IsBlocked { get; set; }

    #endregion Properties
}
