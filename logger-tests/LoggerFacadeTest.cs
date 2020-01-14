using System;
using logger;
using logger.LogStrategies;
using Moq;
using Xunit;

namespace logger_tests
{
    public class LoggerFacadeTest
    {

        [Fact]
        void ShouldLogEverything()
        {
            // Arrange
            var logStrategy = new Mock<ILogStrategy>();
            logStrategy.Setup(x => x.WriteMessage(It.IsAny<string>())).Verifiable();
            var logger = new LoggerFacade<RawLogger>(new LoggerSettings
            {
                LogLevel = LogLevel.Debug | LogLevel.Error | LogLevel.Fatal | LogLevel.Info | LogLevel.Warn,
                DefaultLogStrategy = logStrategy.Object
            });

            // Act
            logger.Debug("debug");
            logger.Error("error");
            logger.Fatal("fatal");
            logger.Info("info;");
            logger.Warn("warm;");

            // Assert
            logStrategy.Verify(x => x.WriteMessage(It.IsAny<string>()), Times.Exactly(5));


            foreach (var logLevel in Enum.GetNames(typeof(LogLevel)))
            {
                if (logLevel != $"{LogLevel.None}")
                {
                    logStrategy.Verify(x => x.WriteMessage(It.Is<string>(s => s.Contains(logLevel))), Times.Once);
                }
            }
        }

        
        [Fact]
        void ShouldNotLogEverything()
        {
            // Arrange
            var logStrategy = new Mock<ILogStrategy>();
            logStrategy.Setup(x => x.WriteMessage(It.IsAny<string>())).Verifiable();
            var shouldLog = LogLevel.Fatal | LogLevel.Info | LogLevel.Warn;
            var logger = new LoggerFacade<RawLogger>(new LoggerSettings
            {
                LogLevel = shouldLog,
                DefaultLogStrategy = logStrategy.Object
            });

            // Act
            logger.Debug("debug");
            logger.Error("error");
            logger.Fatal("fatal");
            logger.Info("info;");
            logger.Warn("warm;");

            // Assert
            logStrategy.Verify(x => x.WriteMessage(It.IsAny<string>()), Times.Exactly(3));


            foreach (var logLevel in Enum.GetValues(typeof(LogLevel)))
            {
                var logLevelEnum = (LogLevel) logLevel;
                if ((logLevelEnum & shouldLog) != LogLevel.None)
                {
                    logStrategy.Verify(x => x.WriteMessage(It.Is<string>(s => s.Contains($"{logLevelEnum}"))), Times.Once);
                }
            }
        }
    }
}
