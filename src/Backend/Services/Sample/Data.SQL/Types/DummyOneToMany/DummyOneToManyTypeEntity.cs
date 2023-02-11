// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL.Types.DummyOneToMany;

/// <summary>
/// Сущность типа "Фиктивное отношение один ко многим".
/// 
/// Служит для демонстрации связи одного экземпляра одной сущности
/// со многими экземплярами другой сущности.
///
/// Один экземпляр сущности "Фиктивное отношение один ко многим"
/// связан со многими экземплярами сущности "Фиктивное главное".
/// </summary>
public class DummyOneToManyTypeEntity
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

    #endregion Properties
}
