using Company.Learn.Cross.Common;
using Microsoft.Extensions.Logging;

namespace Company.Learn.Cross.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        #region Fields
        private readonly ILogger<T> _logger;
        #endregion

        #region Builders
        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }
        #endregion

        #region Methods
        public void LogError(string message, params object[] args)
        {
            _logger.LogError(message, args);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }
        #endregion
    }
}
