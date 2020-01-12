using System;
using client_generator.App.Commands;
using client_generator.Models;
using Terminal.Gui;

namespace client_generator.App.Windows.MenuWindowStates
{
    internal class OpenApiModeWasCreatedState : IMenuWindowState
    {

        private readonly ICommand _editSettingCommand;

        private readonly ICommand _exitCommand;

        private readonly ICommand _generateCommand;

        private MenuWindow _window;

        public OpenApiModeWasCreatedState(OpenApiModel openApiModel, ICommand exitCommand)
        {
            _exitCommand = exitCommand;

            _editSettingCommand = new EditGeneratorSettingsCommand(AppController.Instance().Generator.GetSettings());

            _generateCommand = new GenerateCommand(openApiModel, OnSuccess, OnError);
        }

        public void SetWindow(MenuWindow window)
        {
            _window = window;
        }

        public void DisplayMenu()
        {
            var generateButton = new Button("Generate client")
                {X = Pos.Center(), Y = Pos.Percent(20), Clicked = _generateCommand.Execute};
            var settingsButton = new Button("Change settings")
                {X = Pos.Center(), Y = Pos.Bottom(generateButton), Clicked = _editSettingCommand.Execute};
            var exitButton = new Button("Exit")
                {X = Pos.Center(), Y = Pos.Bottom(settingsButton), Clicked = _exitCommand.Execute};

            _window.Add(generateButton, settingsButton, exitButton);
        }

        private void OnError(Exception exception)
        {
            AppController.GetLogger().Fatal(exception.Message);
            MessageBox.ErrorQuery(_window.Frame.Width, 8, "Error", exception.Message, "Ok");
            _exitCommand.Execute();
        }

        private void OnSuccess()
        {
            AppController.GetLogger().Info("The generation was successful.");
            MessageBox.Query(_window.Frame.Width, 8, "Ok", "The generation was successful.", "Ok");
            _exitCommand.Execute();
        }

    }
}
