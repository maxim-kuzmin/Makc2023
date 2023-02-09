// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Serialization.Json;

/// <summary>
/// Опции сериализации JSON.
/// </summary>
public static class JsonSerializationOptions
{
    #region Properties

    /// <summary>
    /// Для конфигурации.
    /// </summary>
    public static JsonSerializerOptions ForConfig { get; } = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Для JavaScript.
    /// </summary>
    public static JsonSerializerOptions ForJavaScript { get; } = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Для регистратора.
    /// </summary>
    public static JsonSerializerOptions ForLogger { get; } = new()
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never
    };

    #endregion Properties
}