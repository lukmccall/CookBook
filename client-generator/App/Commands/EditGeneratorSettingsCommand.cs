using client_generator.App.Windows;
using client_generator.Generators;

namespace client_generator.App.Commands
{
    public class EditGeneratorSettingsCommand : ICommand
    {

        private readonly GeneratorSettings _generatorSettings;

        public EditGeneratorSettingsCommand(GeneratorSettings generatorSettings)
        {
            _generatorSettings = generatorSettings;
        }

        public void Execute()
        {
            var changeToPriviesWindow = new ChangeWindowCommand(AppController.Instance().GetCurrentWindow());
            var changeToFileSelector =
                new ChangeWindowCommand(new GeneratorSettingsWindow(() => { changeToPriviesWindow.Execute(); },
                    _generatorSettings));

            changeToFileSelector.Execute();
        }

    }
}
