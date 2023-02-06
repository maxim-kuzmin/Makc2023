// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Components.Integration;

/// <summary>
/// Информация о подписке на событие.
/// </summary>
public class SubscriptionInfo
{
    #region Properties

    /// <summary>
    /// Признак подписки на динамическое событие.
    /// </summary>
    public bool IsDynamic { get; }

    /// <summary>
    /// Тип обработчика события.
    /// </summary>
    public Type HandlerType { get; }

    #endregion Properties

    #region Constructors

    private SubscriptionInfo(bool isDynamic, Type handlerType)
    {
        IsDynamic = isDynamic;
        HandlerType = handlerType;
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Создать информацию о подписке на динамическое событие.
    /// </summary>
    /// <param name="handlerType">Тип обработчика.</param>
    /// <returns>Информация о подписке на событие.</returns>
    public static SubscriptionInfo Dynamic(Type handlerType) => new(true, handlerType);

    /// <summary>
    /// Создать информацию о подписке на типизированное событие.
    /// </summary>
    /// <param name="handlerType">Тип обработчика.</param>
    /// <returns>Информация о подписке на событие.</returns>
    public static SubscriptionInfo Typed(Type handlerType) => new(false, handlerType);

    #endregion Public methods
}
