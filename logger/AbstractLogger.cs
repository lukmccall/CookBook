using logger.LogStrategies;

namespace logger
{
    public abstract class AbstractLogger
    {

        private ILogStrategy _logStrategy;

        private AbstractLogger _nextLogger;

        protected LogLevel LogLevel { get; private set; }

        public AbstractLogger Init(LogLevel logLevel, ILogStrategy logStrategy)
        {
            LogLevel = logLevel;
            _logStrategy = logStrategy;
            return this;
        }

        protected virtual void WriteMessage(string message)
        {
            _logStrategy.WriteMessage(message);
        }

        public void SetNextLogger(AbstractLogger nextLogger)
        {
            _nextLogger = nextLogger;
        }

        public void LogMessage(LogLevel level, string message)
        {
            if (LogLevel == level)
            {
                WriteMessage($"{message}");
                return;
            }

            _nextLogger?.LogMessage(level, message);
        }

    }
}
