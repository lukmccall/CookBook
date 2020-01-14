using client_generator.App;
using client_generator.App.Commands;
using Moq;
using Terminal.Gui;
using Xunit;

namespace client_generator_tests.App.Commands
{
    public class ChangeWindowCommandTest
    {

        [Fact]
        public void ChangeWindow()
        {
            // Arrange
            var window = new Mock<Window>(null);
            var appController = new Mock<IAppController>();
            appController.Setup(x => x.ChangeWindow(window.Object)).Verifiable();
            var command = new ChangeWindowCommand(appController.Object, window.Object);
            
            // Act
            command.Execute();

            // Assert
            appController.Verify(x => x.ChangeWindow(It.IsAny<Window>()), Times.Once);
            appController.Verify(x => x.ChangeWindow(window.Object), Times.Once);
        }

        [Fact]
        public void ConstructionShouldBeEffectless()
        {
            // Arrange
            var window = new Mock<Window>(null);
            var appController = new Mock<IAppController>();
            appController.Setup(x => x.ChangeWindow(window.Object)).Verifiable();
            
            // Act
            var command = new ChangeWindowCommand(appController.Object, window.Object);

            appController.Verify(x => x.ChangeWindow(It.IsAny<Window>()), Times.Never);
            
        }

    }
}
