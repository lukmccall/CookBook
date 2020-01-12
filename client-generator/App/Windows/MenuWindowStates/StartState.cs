using client_generator.App.Commands;
using Terminal.Gui;

namespace client_generator.App.Windows.MenuWindowStates
{
    internal class StartState : IMenuWindowState
    {

        private readonly ICommand _exitCommand;

        private readonly ICommand _selectFileCommand;

        private MenuWindow _window;

        public StartState(ICommand selectFileCommand, ICommand exitCommand)
        {
            _selectFileCommand = selectFileCommand;
            _exitCommand = exitCommand;
        }

        public void SetWindow(MenuWindow window)
        {
            _window = window;
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
