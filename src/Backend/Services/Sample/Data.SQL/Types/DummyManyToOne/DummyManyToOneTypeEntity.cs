// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyManyToOne;

/// <summary>
/// Сущность типа "Фиктивное отношение многие к одному".
/// 
/// Служит для демонстрации связи многих экземпляров одной сущности
/// со одним экземпляром другой сущности.
/// 
/// Многие экземпляры сущности "Фиктивное отношение многие к одному"
/// связаны с одним экземпляром сущности "Фиктивное главное".
/// </summary>
public class DummyManyToOneTypeEntity
{
    #region Properties

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Идентификатор экземпляра сущности "Фиктивное главное".
    /// </summary>
    public long DummyMainId { get;  set; }

    #endregion Properties    
}
