using logger;
using logger.LogStrategies;
using Moq;
using Xunit;

namespace logger_tests
{
    public class RawLoggerTest
    {

        [Fact]
        public void ShouldChainCorrectly()
        {
            // Arrange
            var logStrategy = new Mock<ILogStrategy>();
            logStrategy.Setup(x => x.WriteMessage(It.IsAny<string>())).Verifiable();

            var debugLogger = new RawLogger().Init(LogLevel.Debug, logStrategy.Object);
            var infoLogger = new RawLogger().Init(LogLevel.Info, logStrategy.Object);
            var fatalLogger = new RawLogger().Init(LogLevel.Fatal, logStrategy.Object);

            debugLogger.SetNextLogger(infoLogger);
            infoLogger.SetNextLogger(fatalLogger);

            // Act
            debugLogger.LogMessage(LogLevel.Debug, "debug");
            debugLogger.LogMessage(LogLevel.Info, "info");
            debugLogger.LogMessage(LogLevel.Fatal, "fatal");

            // Assert
            logStrategy.Verify(x => x.WriteMessage(It.IsAny<string>()), Times.Exactly(3));
            logStrategy.Verify(x => x.WriteMessage(It.Is<string>(s => s.Contains($"{LogLevel.Debug}"))), Times.Once);
            logStrategy.Verify(x => x.WriteMessage(It.Is<string>(s => s.Contains($"{LogLevel.Info}"))), Times.Once);
            logStrategy.Verify(x => x.WriteMessage(It.Is<string>(s => s.Contains($"{LogLevel.Fatal}"))), Times.Once);
        }

        [Fact]
        public void ShouldBeIgnored()
        {
            // Arrange
            var logStrategy = new Mock<ILogStrategy>();
            logStrategy.Setup(x => x.WriteMessage(It.IsAny<string>())).Verifiable();
            var infoLogger = new RawLogger().Init(LogLevel.Info, logStrategy.Object);

            // Act
            infoLogger.LogMessage(LogLevel.Info, "info");

            // Assert
            logStrategy.Verify(x => x.WriteMessage(It.IsAny<string>()), Times.Never);
        }

    }
}
