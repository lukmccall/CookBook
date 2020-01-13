namespace client_generator.App.Commands
{
    public class ExitAppCommand : ICommand
    {

        private readonly IAppController _appController;

        public ExitAppCommand(IAppController appController)
        {
            _appController = appController;
        }

        public void Execute()
        {
            _appController.ExitApp();
        }

    }
}
