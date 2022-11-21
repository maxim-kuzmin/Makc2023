// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Exceptions;

/// <summary>
/// Исключение переменной.
/// </summary>
public abstract class VariableException : Exception
{
    #region Properties

    /// <summary>
    /// Имя переменной.
    /// </summary>
    public string VariableName { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="variableNameParts">Части имени переменной.</param>
    public VariableException(params string[] variableNameParts)
        : this(null, variableNameParts)
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="type">Тип, содержащий переменную.</param>
    /// <param name="variableNameParts">Части имени переменной.</param>
    public VariableException(Type? type, params string[] variableNameParts)
    {
        string? typeName = type?.FullName;
        string variableName = string.Join(".", variableNameParts);

        VariableName = typeName is not null ? $"{typeName}: {variableName}" : variableName;
    }

    #endregion Constructors
}

/// <summary>
/// Исключение переменной.
/// </summary>
/// <typeparam name="T">Тип, содержащий переменную.</typeparam>
public abstract class VariableException<T> : VariableException
{
    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="variableNameParts">Части имени переменной.</param>
    public VariableException(params string[] variableNameParts) : base(typeof(T), variableNameParts)
    {
    }

    #endregion Constructors
}
