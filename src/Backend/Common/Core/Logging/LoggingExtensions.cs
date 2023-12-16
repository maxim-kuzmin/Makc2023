// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Logging
{
    /// <summary>
    /// Расширения ведения журнала.
    /// </summary>
    public static class LoggingExtensions
    {
        #region Public methods

        /// <summary>
        /// Попробовать загрузить состояние регистратора.
        /// </summary>
        /// <typeparam name="TPropertyValue">Тип значения свойства.</typeparam>
        /// <param name="loggerState">Состояние регистратора.</param>
        /// <param name="key">Ключ.</param>
        /// <param name="actionToSetPropertyValue">Действие по установке значения свойства.</param>
        /// <returns>Признак успешности выполнения действия.</returns>
        public static bool TryLoadLoggerState<TPropertyValue>(
            this Dictionary<string, object> loggerState,
            string key,
            Action<TPropertyValue> actionToSetPropertyValue
            )
        {
            if (!loggerState.TryGetValue(key, out object? value))
                return false;

            actionToSetPropertyValue.Invoke((TPropertyValue)value);

            return true;
        }

        #endregion Public methods
    }
}
