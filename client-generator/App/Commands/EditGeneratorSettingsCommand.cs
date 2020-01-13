using client_generator.App.Windows;
using client_generator.Generators;

namespace client_generator.App.Commands
{
    public class EditGeneratorSettingsCommand : ICommand
    {

        private readonly IAppController _appController;

        private readonly GeneratorSettings _generatorSettings;

        public EditGeneratorSettingsCommand(IAppController appController,GeneratorSettings generatorSettings)
        {
            _appController = appController;
            _generatorSettings = generatorSettings;
        }

        public void Execute()
        {
            var changeToPriviesWindow = new ChangeWindowCommand(_appController, _appController.GetCurrentWindow());
            var changeToFileSelector =
                new ChangeWindowCommand(_appController, new GeneratorSettingsWindow(() => { changeToPriviesWindow.Execute(); },
                    _generatorSettings));

            changeToFileSelector.Execute();
        }

    }
}
