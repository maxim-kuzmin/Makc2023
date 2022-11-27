// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using NLog;

namespace Makc2023.Backend.Core.App
{
    /// <summary>
    /// Обработчик приложения.
    /// </summary>
    public abstract class AppHandler : IDisposable
    {
        #region Fields

        private bool _disposedValue;

        #endregion Fields

        #region Properties

        private Logger Logger { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Конструктор.
        /// </summary>
        public AppHandler()
        {
            Logger = CreateLogger();
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
            Logger.Error(exception, "Stopped program because of exception");
        }

        /// <summary>
        /// Обработать начало.
        /// </summary>
        public void OnStart()
        {
            Logger.Debug($"init main: {Environment.MachineName}");
        }

        #endregion Public methods

        #region Protected methods

        /// <summary>
        /// Создать регистратор.
        /// </summary>
        /// <returns>Регистратор.</returns>
        protected abstract Logger CreateLogger();

        /// <inheritdoc/>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    LogManager.Shutdown();
                }

                _disposedValue = true;
            }
        }

        #endregion Protected methods
    }
}
