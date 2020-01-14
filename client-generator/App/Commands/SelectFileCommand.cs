using client_generator.App.Windows;

namespace client_generator.App.Commands
{
    public class SelectFileCommand : ICommand
    {

        private readonly IAppController _appController;

        private readonly FileSelectorReceiver _fileSelectorReceiver;

        public SelectFileCommand(IAppController appController, FileSelectorReceiver fileSelectorReceiver)
        {
            _appController = appController;
            _fileSelectorReceiver = fileSelectorReceiver;
        }

        public void Execute()
        {
            var changeToPriviesWindow = new ChangeWindowCommand(_appController, _appController.GetCurrentWindow());
            var changeToFileSelector = new ChangeWindowCommand(_appController, new FileSelectorWindow(file =>
            {
                _fileSelectorReceiver.Invoke(file);
                changeToPriviesWindow.Execute();
            }));

            changeToFileSelector.Execute();
        }

    }
}
