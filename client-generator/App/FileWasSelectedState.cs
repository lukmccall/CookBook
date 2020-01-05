using client_generator.App.Commands;
using client_generator.App.Windows;
using Terminal.Gui;

namespace client_generator.App
{
    class FileWasSelectedState : IMenuWindowState
    {

        private readonly ICommand _exitCommand;

        private MenuWindow _window;
        
        private readonly FileSystemEntry _file;

        public FileWasSelectedState(ICommand exitCommand, FileSystemEntry file)
        {
            _exitCommand = exitCommand;
            _file = file;
        }

        public void SetWindow(MenuWindow window)
        {
            _window = window;
        }

        public void DisplayMenu()
        {
            var fileLabel = new Label(1,1, $"Selected file: {_file.FileName}");
            
            var checkButton = new Button("Check current file.")
                {X = Pos.Center(), Y = Pos.Percent(20)};
            var deserializeButton = new Button("Deserialize selected file.")
                {X = Pos.Center(), Y = Pos.Bottom(checkButton)};
            var exitButton = new Button("Exit")
                {X = Pos.Center(), Y = Pos.Bottom(deserializeButton), Clicked = _exitCommand.Execute};
            
            _window.Add(fileLabel, checkButton,deserializeButton, exitButton);
        }

    }
}
