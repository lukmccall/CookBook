using client_generator.App;
using client_generator.App.Commands;
using Moq;
using Terminal.Gui;
using Xunit;

namespace client_generator_tests.App.Commands
{
    public class ExitCommandTest
    {

        [Fact]
        public void Exit()
        {
            // Arrange
            var appController = new Mock<IAppController>();
            appController.Setup(x => x.ExitApp()).Verifiable();
            var command = new ExitAppCommand(appController.Object);

            // Act
            command.Execute();

            // Assert
            appController.Verify(x => x.ExitApp(), Times.Once);
        }

        [Fact]
        public void ConstructionShouldBeEffectless()
        {
            // Arrange
            var appController = new Mock<IAppController>();
            appController.Setup(x => x.ExitApp()).Verifiable();

            // Act
            var command = new ExitAppCommand(appController.Object);
                
            // Assert
            appController.Verify(x => x.ExitApp(), Times.Never);
        }

    }
}
