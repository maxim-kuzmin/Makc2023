// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Data.SQL;

/// <summary>
/// Параметры типов.
/// </summary>
public abstract class TypesOptions
{
    #region Properties

    /// <summary>
    /// Сущность "Фиктивное главное".
    /// </summary>
    public DummyMainTypeOptions DummyMain { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public DummyMainDummyManyToManyTypeOptions DummyMainDummyManyToMany { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Фиктивное отношение многие ко многим".
    /// </summary>
    public DummyManyToManyTypeOptions DummyManyToMany { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Фиктивное отношение многие ко одному".
    /// </summary>
    public DummyManyToOneTypeOptions DummyManyToOne { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Фиктивное отношение один ко многим".
    /// </summary>
    public DummyOneToManyTypeOptions DummyOneToMany { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Фиктивное дерево".
    /// </summary>
    public DummyTreeTypeOptions DummyTree { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Связь фиктивного дерева".
    /// </summary>
    public DummyTreeLinkTypeOptions DummyTreeLink { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Внутренний домен".
    /// </summary>
    public InternalDomainTypeOptions InternalDomain { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Внутреннее разрешение".
    /// </summary>
    public InternalPermissionTypeOptions InternalPermission { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Пользователь".
    /// </summary>
    public UserTypeOptions User { get; protected set; } = null!;

    /// <summary>
    /// Сущность "Внутреннее разрешение пользователя".
    /// </summary>
    public UserInternalPermissionTypeOptions UserInternalPermission { get; protected set; } = null!;

    #endregion Properties
}