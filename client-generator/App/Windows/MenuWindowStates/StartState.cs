using client_generator.App.Commands;
using Terminal.Gui;

namespace client_generator.App.Windows.MenuWindowStates
{
    internal class StartState : IMenuWindowState
    {

        private readonly ICommandsProvider _commandsProvider;

        private readonly ICommand _exitCommand;

        private ICommand _selectFileCommand;

        private MenuWindow _window;

        public StartState(ICommandsProvider commandsProvider)
        {
            _commandsProvider = commandsProvider;

            _exitCommand = commandsProvider.ExitCommand();
        }

        public void SetWindow(MenuWindow window)
        {
            _window = window;

            _selectFileCommand =
                _commandsProvider.ShowPopupWindowCommand(new FileSelectorWindow(), _window.FileWasSelected, _window);
        }

        public void DisplayMenu()
        {
            var loadButton = new Button("Load the openApi.json")
                {X = Pos.Center(), Y = Pos.Percent(20), Clicked = _selectFileCommand.Execute};
            var exitButton = new Button("Exit")
                {X = Pos.Center(), Y = Pos.Bottom(loadButton), Clicked = _exitCommand.Execute};

            _window.Add(loadButton, exitButton);
        }

    }
}
