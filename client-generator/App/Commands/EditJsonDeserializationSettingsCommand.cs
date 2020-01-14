using client_generator.App.Windows;
using Newtonsoft.Json;

namespace client_generator.App.Commands
{
    public class EditJsonDeserializationSettingsCommand : ICommand
    {

        private readonly IAppController _appController;

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public EditJsonDeserializationSettingsCommand(IAppController appController,
            JsonSerializerSettings jsonSerializerSettings)
        {
            _appController = appController;
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public void Execute()
        {
            var changeToPriviesWindow = new ChangeWindowCommand(_appController, _appController.GetCurrentWindow());
            var changeToFileSelector =
                new ChangeWindowCommand(_appController, new JsonSettingsWindow(
                    () => { changeToPriviesWindow.Execute(); },
                    _jsonSerializerSettings));

            changeToFileSelector.Execute();
        }

    }
}
