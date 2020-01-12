using client_generator.App.Commands;
using client_generator.App.Windows.MenuWindowStates;
using Terminal.Gui;

namespace client_generator.App.Windows
{
    public class MenuWindow : Window
    {

        private readonly ICommand _exitCommand = new ExitAppCommand();

        private readonly ICommand _selectFileCommand;


        private IMenuWindowState _state;

        public MenuWindow() : base("Code Generator - Menu")
        {
            _selectFileCommand = new SelectFileCommand(FileWasSelected);
            ChangeState(new StartState(_selectFileCommand, _exitCommand));
        }

        private void FileWasSelected(FileSystemEntry file)
        {
            ChangeState(new FileWasSelectedState(file, _selectFileCommand, _exitCommand));
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
            LayoutSubviews();
            FocusFirst();
        }

    }
}
