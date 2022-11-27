// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Core;

/// <summary>
/// Загрузчик.
/// </summary>
/// <typeparam name="TLoadable">Загружаемый тип.</typeparam>
public abstract class Loader<TLoadable>
{
    #region Properties

    /// <summary>
    /// Цель.
    /// </summary>
    public TLoadable Target { get; set; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="target">Цель.</param>
    public Loader(TLoadable target)
    {
        Target = target;
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Загрузить.
    /// </summary>
    /// <param name="source">Источник.</param>
    /// <param name="loadableProperties">Загружаемые свойства.</param>
    /// <returns>Загруженные свойства.</returns>
    public virtual HashSet<string> Load(TLoadable source, HashSet<string>? loadableProperties = null)
    {
        return loadableProperties ?? CreateAllPropertiesToLoad();
    }

    #endregion Public methods

    #region Protected methods

    /// <summary>
    /// Создать все свойства для загрузки.
    /// </summary>
    /// <returns>Все свойства для загрузки.</returns>
    protected abstract HashSet<string> CreateAllPropertiesToLoad();

    #endregion Protected methods
}