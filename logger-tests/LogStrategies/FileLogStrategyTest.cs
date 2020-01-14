using System;
using System.IO;
using logger.LogStrategies;
using Xunit;

namespace logger_tests.LogStrategies
{
    public class FileLogStrategyTest
    {

        [Fact]
        public void FileWasCreated()
        {
            // Arrange
            const string logFile = "newFileLog.logs";
            const string message = "message";

            var logStrategy = new FileLogStrategy(logFile);

            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }

            // Act
            logStrategy.WriteMessage(message);

            // Assert
            Assert.True(File.Exists(logFile), "File should exist.");
            var content = File.ReadAllText(logFile);
            Assert.Equal($"{message}{Environment.NewLine}", content);
        }

        [Fact]
        public void ShouldAppend()
        {
            // Arrange
            const string logFile = "appendLog.logs";
            const string message = "message";
            const string secondMessage = "secondMessage";

            var logStrategy = new FileLogStrategy(logFile);

            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }

            // Act
            logStrategy.WriteMessage(message);
            logStrategy.WriteMessage(secondMessage);

            // Assert
            Assert.True(File.Exists(logFile), "File should exist.");
            var content = File.ReadAllText(logFile);
            Assert.Equal($"{message}{Environment.NewLine}{secondMessage}{Environment.NewLine}", content);
        }

        [Fact]
        public void ShouldAppendEvenWithDifferentInstance()
        {
            // Arrange
            const string logFile = "appendLog.logs";
            const string message = "message";
            const string secondMessage = "secondMessage";

            var logStrategy = new FileLogStrategy(logFile);
            var secondLogStrategy = new FileLogStrategy(logFile);

            if (File.Exists(logFile))
            {
                File.Delete(logFile);
            }

            // Act
            logStrategy.WriteMessage(message);
            secondLogStrategy.WriteMessage(secondMessage);

            // Assert
            Assert.True(File.Exists(logFile), "File should exist.");
            var content = File.ReadAllText(logFile);
            Assert.Equal($"{message}{Environment.NewLine}{secondMessage}{Environment.NewLine}", content);
        }

    }
}
