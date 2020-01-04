using Terminal.Gui;

namespace client_generator.App.Commands
{
    public class ChangeWindowCommand : ICommand
    {

        private readonly Window _windowToChange;

        public ChangeWindowCommand(Window windowToChange)
        {
            _windowToChange = windowToChange;
        }

        public void Execute()
        {
            AppController.Instance().ChangeWindow(_windowToChange);
        }

    }
}
