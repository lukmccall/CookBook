using System;
using client_generator.App;
using client_generator.App.Commands;
using client_generator.App.Windows;
using client_generator.Generators;
using Moq;
using Newtonsoft.Json;
using Terminal.Gui;
using Xunit;

namespace client_generator_tests.App.Commands
{
    public class CommandWithConnectedWindow
    {

        [Fact]
        public void OnExecuteShouldChangeWindow()
        {
            // Arrange
            var window = new Mock<Window>(null);
            var appController = new Mock<IAppController>();
            appController.Setup(x => x.GetCurrentWindow()).Returns(window.Object);
            appController.Setup(x => x.ChangeWindow(It.IsAny<Window>())).Verifiable();

            var commands = new (Type type, ICommand command)[]
            {
                (typeof(GeneratorSettingsWindow),
                    new EditGeneratorSettingsCommand(appController.Object, new GeneratorSettings())),
                
                (typeof(JsonSettingsWindow),
                    new EditJsonDeserializationSettingsCommand(appController.Object, new JsonSerializerSettings())),
                
                (typeof(FileSelectorWindow),
                    new SelectFileCommand(appController.Object, entry => {} ))
            };

            // Act 
            foreach (var (_, command) in commands)
            {
                command.Execute();
            }

            // Assert
            foreach (var (type, _) in commands)
            {
                appController.Verify(
                    x => x.ChangeWindow(It.Is<Window>(changedWindow =>
                        changedWindow.GetType() == type)), Times.Once);
            }
        }

    }
}
