using client_generator.App.Windows;

namespace client_generator.App.Commands
{
    public class SelectFileCommand : ICommand
    {

        private FileSelectorReceiver _fileSelectorReceiver;

        public SelectFileCommand(FileSelectorReceiver fileSelectorReceiver)
        {
            _fileSelectorReceiver = fileSelectorReceiver;
        }

        public void Execute()
        {
            var changeToPriviesWindow = new ChangeWindowCommand(AppController.Instance().GetCurrentWindow());
            var changeToFileSelector = new ChangeWindowCommand(new FileSelectorWindow(file =>
            {
                _fileSelectorReceiver.Invoke(file);
                _fileSelectorReceiver = null;

                changeToPriviesWindow.Execute();
            }));

            changeToFileSelector.Execute();
        }

    }
}
