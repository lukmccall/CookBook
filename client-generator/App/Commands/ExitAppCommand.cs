namespace client_generator.App.Commands
{
    public class ExitAppCommand : ICommand
    {

        public void Execute()
        {
            AppController.Instance().ExitApp();
        }

    }
}
