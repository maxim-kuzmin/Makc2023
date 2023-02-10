﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Services.Sample.Domains.DummyMain
{
    /// <summary>
    /// Интерфейс ресурса домена.
    /// </summary>
    public interface IDomainResource
    {
        #region Methods

        /// <summary>
        /// Получить сообщение об ошибке, возникающей в случае, если сущность не найдена.
        /// </summary>
        /// <returns>Сообщение об ошибке.</returns>
        string GetErrorMessageForEntityNotFound();

        /// <summary>
        /// Получить имя операции получения элемента.
        /// </summary>
        /// <returns>Имя операции.</returns>
        string GetItemGetOperationName();

        /// <summary>
        /// Получить имя операции получения списка.
        /// </summary>
        /// <returns>Имя операции.</returns>
        string GetListGetOperationName();

        #endregion Methods
    }
}
