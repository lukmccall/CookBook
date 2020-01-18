using System;
using client_generator.App.Commands;
using client_generator.Models;
using Newtonsoft.Json;
using Terminal.Gui;

namespace client_generator.App.Windows.MenuWindowStates
{
    internal class FileWasSelectedState : IMenuWindowState
    {

        private readonly ICommand _deserializationCommand;

        private ICommand _editJsonDeserializationSettings;

        private readonly ICommand _exitCommand;

        private readonly FileSystemEntry _file;

        private readonly ICommandsProvider _commandsProvider;

        private readonly JsonSerializerSettings
            _jsonSerializerSettings = new JsonSerializerSettings(); // set up default settings

        private ICommand _selectFileCommand;

        private MenuWindow _window;

        public FileWasSelectedState(FileSystemEntry file, ICommandsProvider commandsProvider)
        {
            _file = file;
            _commandsProvider = commandsProvider;
            _exitCommand = commandsProvider.ExitCommand();

            _deserializationCommand =
                commandsProvider.DeserializationCommand(file, _jsonSerializerSettings, OnDeserialization, OnError);
        }

        public void SetWindow(MenuWindow window)
        {
            _window = window;

            _selectFileCommand =
                _commandsProvider.ShowPopupWindowCommand(new FileSelectorWindow(), _window.FileWasSelected, _window);

            _editJsonDeserializationSettings = _commandsProvider.ShowPopupWindowCommand(
                new JsonSettingsWindow(_jsonSerializerSettings), null, _window);
        }

        public void DisplayMenu()
        {
            var fileLabel = new Label(1, 1, $"Selected file: {_file.FileName}");

            var checkButton = new Button("Deserialize current file")
                {X = Pos.Center(), Y = Pos.Percent(20), Clicked = _deserializationCommand.Execute};
            var changeSettings = new Button("Change deserialization settings")
                {X = Pos.Center(), Y = Pos.Bottom(checkButton), Clicked = _editJsonDeserializationSettings.Execute};
            var changeFile = new Button("Change file")
                {X = Pos.Center(), Y = Pos.Bottom(changeSettings), Clicked = _selectFileCommand.Execute};
            var exitButton = new Button("Exit")
                {X = Pos.Center(), Y = Pos.Bottom(changeFile), Clicked = _exitCommand.Execute};

            _window.Add(fileLabel, checkButton, changeSettings, changeFile, exitButton);
        }

        private void OnError(Exception exception)
        {
            AppController.GetLogger().Error(exception.Message);
            MessageBox.ErrorQuery(_window.Frame.Width, 8, "Deserialization failed", exception.Message, "Ok");
        }

        private void OnDeserialization(OpenApiModel openApiModel)
        {
            _window.ChangeState(new OpenApiModeWasCreatedState(openApiModel, _commandsProvider));
        }

    }
}
