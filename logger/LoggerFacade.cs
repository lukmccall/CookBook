using System;
using System.Collections.Generic;
using System.Linq;

namespace logger
{
    public class LoggerFacade<T> : ILogger where T : AbstractLogger, new()
    {

        private readonly AbstractLogger _logger;

        public LoggerFacade(LoggerSettings settings)
        {
            var loggerChain = new List<AbstractLogger>();
            var logLevels = Enum.GetValues(typeof(LogLevel)).Cast<LogLevel>();
            foreach (var level in logLevels)
            {
                if ((level & settings.LogLevel) == LogLevel.None)
                {
                    continue;
                }

                var strategy = settings.DefaultLogStrategy;
                if (settings.OverridenLogStrategies.ContainsKey(level))
                {
                    strategy = settings.OverridenLogStrategies[level];
                }

                var logger = new T().Init(level, strategy);

                if (loggerChain.Count > 0)
                {
                    loggerChain.Last().SetNextLogger(logger);
                }

                loggerChain.Add(logger);
            }

            _logger = loggerChain.First() ?? new T().Init(LogLevel.None, null);
        }

        public void Debug(string message)
        {
            _logger.LogMessage(LogLevel.Debug, message);
        }

        public void Info(string message)
        {
            _logger.LogMessage(LogLevel.Info, message);
        }

        public void Warn(string message)
        {
            _logger.LogMessage(LogLevel.Warn, message);
        }

        public void Error(string message)
        {
            _logger.LogMessage(LogLevel.Error, message);
        }

        public void Fatal(string message)
        {
            _logger.LogMessage(LogLevel.Fatal, message);
        }

    }
}
