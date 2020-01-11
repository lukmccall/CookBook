using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using logger.LogStrategies;

namespace logger
{
    public class LoggerSettings
    {

        [NotNull]
        public LogLevel LogLevel { get; set; }

        [NotNull]
        public ILogStrategy DefaultLogStrategy { get; set; }

        [NotNull]
        public Dictionary<LogLevel, ILogStrategy> OverridenLogStrategies { get; set; } =
            new Dictionary<LogLevel, ILogStrategy>();

    }
}
