﻿// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2023.Backend.Common.Core.App
{
    /// <summary>
    /// Обработчик приложения.
    /// </summary>
    public abstract class AppHandler : IDisposable
    {
        #region Fields

        private bool _disposedValue;

        private readonly ILoggerOfNLog _logger;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public AppHandler(ILoggerOfNLog logger)
        {
            _logger = logger;
        }

        #endregion Constructors

        #region Public methods

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(disposing: true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Обработать ошибку.
        /// </summary>
        /// <param name="exception">Исключение.</param>
        public void OnError(Exception exception)
        {
            _logger.Error(exception, "Stopped program because of exception");
        }

        /// <summary>
        /// Обработать начало.
        /// </summary>
        public void OnStart()
        {
            _logger.Debug("Started program on the {MachineName} machine", Environment.MachineName);
        }

        #endregion Public methods

        #region Protected methods

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    LogManagerOfNLog.Shutdown();
                }

                _disposedValue = true;
            }
        }

        #endregion Protected methods
    }
}
