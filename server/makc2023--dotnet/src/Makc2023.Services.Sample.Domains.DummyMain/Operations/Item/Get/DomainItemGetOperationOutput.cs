// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Services.Sample.Domains.DummyMain.Operations.Item.Get;

/// <summary>
/// Выходные данные операции получения элемента в домене.
/// </summary>
public class DomainItemGetOperationOutput
{
    #region Properties

    /// <summary>
    /// Экземпляр сущности "Фиктивное главное".
    /// </summary>
    public DummyMainTypeEntity? DummyMain { get; set; }

    /// <summary>
    /// Список экземпляров сущности "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public DummyMainDummyManyToManyTypeEntity[]? DummyMainDummyManyToManyList { get; set; }

    /// <summary>
    /// Список экземпляров сущности "Фиктивное отношение многие ко многим".
    /// </summary>
    public DummyManyToManyTypeEntity[]? DummyManyToManyList { get; set; }

    /// <summary>
    /// Экземпляр сущности "Фиктивное отношение один ко многим".
    /// </summary>
    public DummyOneToManyTypeEntity? DummyOneToMany { get; set; }

    #endregion Properties
}
