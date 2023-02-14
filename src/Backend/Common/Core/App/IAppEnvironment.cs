// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.App;

/// <summary>
/// Интерфейс окружения приложения.
/// </summary>
public interface IAppEnvironment
{
    #region Properties

    /// <summary>
    /// Культура по умолчанию.
    /// </summary>
    string DefaultCulture { get; }

    /// <summary>
    /// Поддерживаемые культуры.
    /// </summary>
    string[] SupportedCultures { get; }

    #endregion Properties
}
