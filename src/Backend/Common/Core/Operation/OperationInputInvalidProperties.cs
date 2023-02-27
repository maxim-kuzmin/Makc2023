// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.Operation;

/// <summary>
/// Cвойства с недействительными значениями во входных данных операции.
/// </summary>
public class OperationInputInvalidProperties
{
    #region Fields

    private readonly Dictionary<string, HashSet<string>> _data = new();

    #endregion Fields

    #region Public methods

    /// <summary>
    /// Проверить, существует ли любое значение.
    /// </summary>
    /// <returns>Результат проверки.</returns>
    public bool Any()
    {
        return _data.Any();
    }

    /// <summary>
    /// Очистить.
    /// </summary>
    public void Clear()
    {
        _data.Clear();
    }

    /// <summary>
    /// Копировать в список именованных значений.
    /// </summary>
    public void CopyToNamedValuesList(List<NamedValues<string>> target)
    {
        foreach (string propertyName in GetPropertyNames())
        {
            var propertyValues = _data[propertyName];

            NamedValues<string> property = new(propertyName);

            property.Values.AddRange(propertyValues);

            target.Add(property);
        }
    }

    /// <summary>
    /// Получить или добавить свойство.
    /// </summary>
    /// <param name="propertyName">Имя свойства.</param>
    /// <returns>Значения существующего или только что добавленного свойства.</returns>
    public HashSet<string> GetOrAdd(string propertyName)
    {
        if (!_data.TryGetValue(propertyName, out HashSet<string>? result))
        {
            result = new();

            _data[propertyName] = result;
        }

        return result;
    }

    /// <summary>
    /// Получить имена свойств.
    /// </summary>
    /// <returns>Имена свойств.</returns>
    public IEnumerable<string> GetPropertyNames()
    {
        return _data.Keys;
    }

    #endregion Public methods
}
