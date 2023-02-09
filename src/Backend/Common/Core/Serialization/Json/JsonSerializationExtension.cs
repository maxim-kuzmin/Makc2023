// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Serialization.Json
{
    /// <summary>
    /// Расширение сериализации JSON.
    /// </summary>
    public static class JsonSerializationExtension
    {
        #region Public methods

        /// <summary>
        /// Глубоко клонировать через JSON.
        /// </summary>
        /// <typeparam name="T">Тип клонируемого значения.</typeparam>
        /// <param name="value">Клонируемое значение.</param>
        /// <returns>Клон.</returns>
        public static T? DeepCloneViaJson<T>(this T? value) where T: class
        {
            return value?.SerializeToJson()?.DeserializeFromJson<T>();
        }

        /// <summary>
        /// Десериализовать из JSON.
        /// </summary>
        /// <typeparam name="T">Тип значения.</typeparam>
        /// <param name="json">Строка в формате JSON.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Значение указанного типа.</returns>
        public static T? DeserializeFromJson<T>(this string? json, JsonSerializerOptions? options = null)
        {
            return string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<T?>(json, options);
        }

        /// <summary>
        /// Сериализовать в JSON.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Строка в формате JSON.</returns>
        public static string SerializeToJson(this object value, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Serialize(value, options);
        }

        /// <summary>
        /// Расширение. JSON. Попробовать десериализовать.
        /// </summary>
        /// <typeparam name="T">Тип значения.</typeparam>
        /// <param name="json">Строка в формате JSON.</param>
        /// <param name="value">Значение указанного типа.</param>
        /// <param name="options">Опции.</param>
        /// <param name="defaultValue">Значение по умолчанию.</param>
        /// <returns>Признак успешности десериализации.</returns>
        public static bool TryDeserializeFromJson<T>(
            this string json,
            out T? value,
            JsonSerializerOptions options,
            T? defaultValue = default
            )
        {
            bool result = true;

            value = defaultValue;

            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    value = DeserializeFromJson<T>(json, options);
                }
                catch
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Попробовать сериализовать в JSON.
        /// </summary>
        /// <param name="obj">Сериализуемый объект.</param>
        /// <param name="value">Строка в формате JSON.</param>
        /// <param name="options">Опции.</param>
        /// <returns>Признак успешности сериализации.</returns>
        public static bool TrySerializeToJson(
            this object obj,
            out string? value,
            JsonSerializerOptions options
            )
        {
            bool result = true;

            value = null;

            if (obj != null)
            {
                try
                {
                    value = SerializeToJson(obj, options);
                }
                catch
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        #endregion Public methods
    }
}