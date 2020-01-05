using System.Threading;
using client_generator.App.Commands;
using Terminal.Gui;

namespace client_generator.App.Windows
{
    public class MenuWindow : Window
    {

        private readonly ICommand _exitCommand = new ExitAppCommand();

        private readonly ICommand _selectFileCommand;
        

        private IMenuWindowState _state;

        public MenuWindow() : base(new Rect(0, 0, Application.Top.Frame.Width, Application.Top.Frame.Height),
            "Code Generator - Menu")
        {
            _selectFileCommand = new SelectFileCommand(FileWasSelected);
            ChangeState(new StartState(_selectFileCommand, _exitCommand));
        }


        void FileWasSelected(FileSystemEntry file)
        {
            ChangeState(new FileWasSelectedState(_exitCommand, file));
        }

        public void ChangeState(IMenuWindowState newState)
        {
            if (_state != null)
            {
                RemoveAll();
            }

            newState.SetWindow(this);
            _state = newState;
            _state.DisplayMenu();
        }

    }
}
