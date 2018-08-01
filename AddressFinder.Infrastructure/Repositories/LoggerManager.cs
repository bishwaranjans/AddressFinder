using AddressFinder.Domain.SeedWork;
using NLog;

namespace AddressFinder.Infrastructure.Repositories
{
    /// <summary>
    /// Logger Manager
    /// </summary>
    /// <seealso cref="AddressFinder.Domain.SeedWork.ILoggerManager" />
    public class LoggerManager : ILoggerManager
    {
        #region Private members
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerManager"/> class.
        /// </summary>
        public LoggerManager()
        {
        }

        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogDebug(string message)
        {
            Logger.Debug(message);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogError(string message)
        {
            Logger.Error(message);
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogInfo(string message)
        {
            Logger.Info(message);
        }

        /// <summary>
        /// Logs the warn.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogWarn(string message)
        {
            Logger.Warn(message);
        }
    }
}
