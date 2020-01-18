using client_generator.App.Commands;
using client_generator.App.Windows.MenuWindowStates;
using Terminal.Gui;

namespace client_generator.App.Windows
{
    public class MenuWindow : Window
    {

        private readonly ICommandsProvider _commandsProvider;


        private IMenuWindowState _state;

        public MenuWindow(ICommandsProvider commandsProvider) : base("Code Generator - Menu")
        {
            _commandsProvider = commandsProvider;


            ChangeState(new StartState(commandsProvider));
        }

        public void FileWasSelected(object obj)
        {
            if (obj is FileSystemEntry file)
            {
                ChangeState(new FileWasSelectedState(file, _commandsProvider));
            }
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
