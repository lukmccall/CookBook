using System;
using client_generator.App.Commands;
using client_generator.App.Windows;
using client_generator.Models;
using Newtonsoft.Json;
using Terminal.Gui;

namespace client_generator.App
{
    class FileWasSelectedState : IMenuWindowState
    {

        private readonly ICommand _selectFileCommand;

        private readonly ICommand _exitCommand;

        private readonly ICommand _deserializationCommand;
        
        private readonly ICommand _editJsonDeserializationSettings;
    
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings();
        
        private MenuWindow _window;

        private readonly FileSystemEntry _file;

        public FileWasSelectedState(FileSystemEntry file, ICommand selectFileCommand, ICommand exitCommand)
        {
            _file = file;
            _exitCommand = exitCommand;
            _selectFileCommand = selectFileCommand;

            _deserializationCommand = new DeserializationCommand(file, _jsonSerializerSettings, OnDeserialization, OnError);
            _editJsonDeserializationSettings = new EditJsonDeserializationSettingsCommand(_jsonSerializerSettings);
        }

        public void SetWindow(MenuWindow window)
        {
            _window = window;
        }

        public void DisplayMenu()
        {
            var fileLabel = new Label(1, 1, $"Selected file: {_file.FileName}");

            var checkButton = new Button("Deserialize current file.")
                {X = Pos.Center(), Y = Pos.Percent(20), Clicked = _deserializationCommand.Execute};
            var changeSettings = new Button("Change deserialization settings.")
                {X = Pos.Center(), Y = Pos.Bottom(checkButton), Clicked = _editJsonDeserializationSettings.Execute};
            var changeFile = new Button("Change file.")
                {X = Pos.Center(), Y = Pos.Bottom(changeSettings), Clicked = _selectFileCommand.Execute};
            var exitButton = new Button("Exit")
                {X = Pos.Center(), Y = Pos.Bottom(changeFile), Clicked = _exitCommand.Execute};


            _window.Add(fileLabel, checkButton, changeSettings, changeFile, exitButton);
        }

        private void OnError(Exception obj)
        {
            
            MessageBox.ErrorQuery(_window.Frame.Width, 8, "Deserialization failed", obj.Message, "Ok");
        }

        private void OnDeserialization(OpenApiModel obj)
        {
            
        }

    }
}
