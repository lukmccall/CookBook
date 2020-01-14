using Terminal.Gui;

namespace client_generator.App.Commands
{
    public class ChangeWindowCommand : ICommand
    {

        private readonly IAppController _appController;

        private readonly Window _windowToChange;

        public ChangeWindowCommand(IAppController appController, Window windowToChange)
        {
            _appController = appController;
            _windowToChange = windowToChange;
        }

        public void Execute()
        {
            _appController.ChangeWindow(_windowToChange);
        }

    }
}
