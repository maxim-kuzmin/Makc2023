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
    public DummyMainTypeOptions DummyMain { get; init; } = null!;

    /// <summary>
    /// Сущность "Фиктивное отношение многие ко многим фиктивного главного".
    /// </summary>
    public DummyMainDummyManyToManyTypeOptions DummyMainDummyManyToMany { get; init; } = null!;

    /// <summary>
    /// Сущность "Фиктивное отношение многие ко многим".
    /// </summary>
    public DummyManyToManyTypeOptions DummyManyToMany { get; init; } = null!;

    /// <summary>
    /// Сущность "Фиктивное отношение многие ко одному".
    /// </summary>
    public DummyManyToOneTypeOptions DummyManyToOne { get; init; } = null!;

    /// <summary>
    /// Сущность "Фиктивное отношение один ко многим".
    /// </summary>
    public DummyOneToManyTypeOptions DummyOneToMany { get; init; } = null!;

    /// <summary>
    /// Сущность "Фиктивное дерево".
    /// </summary>
    public DummyTreeTypeOptions DummyTree { get; init; } = null!;

    /// <summary>
    /// Сущность "Связь фиктивного дерева".
    /// </summary>
    public DummyTreeLinkTypeOptions DummyTreeLink { get; init; } = null!;

    /// <summary>
    /// Сущность "Внутренний домен".
    /// </summary>
    public InternalDomainTypeOptions InternalDomain { get; init; } = null!;

    /// <summary>
    /// Сущность "Внутреннее разрешение".
    /// </summary>
    public InternalPermissionTypeOptions InternalPermission { get; init; } = null!;

    /// <summary>
    /// Сущность "Пользователь".
    /// </summary>
    public UserTypeOptions User { get; init; } = null!;

    /// <summary>
    /// Сущность "Внутреннее разрешение пользователя".
    /// </summary>
    public UserInternalPermissionTypeOptions UserInternalPermission { get; init; } = null!;

    #endregion Properties
}