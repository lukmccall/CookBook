using client_generator.App.Windows;
using Newtonsoft.Json;

namespace client_generator.App.Commands
{
    public class EditJsonDeserializationSettingsCommand : ICommand
    {

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public EditJsonDeserializationSettingsCommand(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public void Execute()
        {
            var changeToPriviesWindow = new ChangeWindowCommand(AppController.Instance().GetCurrentWindow());
            var changeToFileSelector =
                new ChangeWindowCommand(new JsonSettingsWindow(() => { changeToPriviesWindow.Execute(); },
                    _jsonSerializerSettings));

            changeToFileSelector.Execute();
        }

    }
}
