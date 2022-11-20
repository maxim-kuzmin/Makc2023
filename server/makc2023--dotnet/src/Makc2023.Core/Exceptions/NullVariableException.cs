// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Core.Exceptions
{
    /// <summary>
    /// Исключение, выбрасываемое в случае если переменная равна нулю.
    /// </summary>
    public class NullVariableException : Exception
    {
        #region Properties

        /// <summary>
        /// Имя строки.
        /// </summary>
        public string VariableName { get; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="variableNameParts">Части имени переменной.</param>
        public NullVariableException(params string[] variableNameParts)
        {
            VariableName = string.Join(".", variableNameParts);
        }

        #endregion Constructors
    }
}
