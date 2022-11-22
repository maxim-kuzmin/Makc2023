// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Data.Joins;

/// <summary>
/// Соединение "Фиктивное отношение многие ко многим фиктивного главного".
/// 
/// Служит для соединения экземпляров сущностей "Фиктивное главное" и
/// "Фиктивное отношение многие ко многим".
/// </summary>
public class DummyMainDummyManyToManyJoin
{
    #region Properties

    /// <summary>
    /// Идентификатор экземпляра сущности "Фиктивное главное".
    /// </summary>
    public int DummyMainId { get; private set; }

    /// <summary>
    /// Идентификатор экземпляра сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public int DummyManyToManyId { get; private set; }

    #endregion Properties

    #region Navigation properties

    /// <summary>
    /// Сущность "Фиктивное главное".
    /// </summary>
    public DummyMainEntity? DummyMain { get; set; }

    /// <summary>
    /// Сущность "Фиктивное отношение многие ко многим".
    /// </summary>
    public DummyManyToManyEntity? DummyManyToMany { get; set; }

    #endregion Navigation properties
}
