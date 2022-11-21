// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Exceptions.VariableExceptions;

/// <summary>
/// Исключение, выбрасываемое в случае обнаружения в строковой переменной нуля или
/// пустой строки или строки, состоящий только из пробельных символов.
/// </summary>
public class NullOrWhiteSpaceStringVariableException : VariableException
{
    #region Constructors

    /// <inheritdoc/>
    public NullOrWhiteSpaceStringVariableException(params string[] variableNameParts)
        : base(variableNameParts)
    {
    }

    /// <inheritdoc/>
    public NullOrWhiteSpaceStringVariableException(Type type, params string[] variableNameParts)
        : base(type, variableNameParts)
    {
    }

    #endregion Constructors
}

/// <summary>
/// Исключение, выбрасываемое в случае обнаружения в строковой переменной нуля или
/// пустой строки или строки, состоящий только из пробельных символов.
/// </summary>
/// <typeparam name="T">Тип, содержащий переменную.</typeparam>
public class NullOrWhiteSpaceStringVariableException<T> : VariableException<T>
{
    #region Constructors

    /// <inheritdoc/>
    public NullOrWhiteSpaceStringVariableException(params string[] variableNameParts)
        : base(variableNameParts)
    {
    }

    #endregion Constructors
}
