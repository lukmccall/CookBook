using System;
using client_generator.App.Windows.MenuWindowStates;
using client_generator.Models;
using logger;
using Newtonsoft.Json;
using Terminal.Gui;

namespace client_generator.App.Commands
{
    public class CommandsProvider : ICommandsProvider
    {

        private readonly AppController _appController;

        private readonly ILogger _logger;

        public CommandsProvider(AppController appController, ILogger logger)
        {
            _appController = appController;
            _logger = logger;
        }

        public ICommand ExitCommand()
        {
            return new ExitAppCommand(_appController);
        }

        public ICommand ChangeWindowCommand(Window to)
        {
            return new ChangeWindowCommand(_appController, to);
        }

        public ICommand DeserializationCommand(
            FileSystemEntry file,
            JsonSerializerSettings deserializationSettings,
            Action<OpenApiModel> onDeserialization,
            Action<Exception> onError
        )
        {
            return new DeserializationCommand(file, deserializationSettings, onDeserialization, onError);
        }

        public ICommand ShowPopupWindowCommand(
            PopupWindow popupWindow,
            Action<object> receiver,
            Window current
        )
        {
            var returnCommand = ChangeWindowCommand(current);
            popupWindow.SetActionReceiver(o =>
            {
                receiver?.Invoke(o);
                returnCommand.Execute();
            });

            return ChangeWindowCommand(popupWindow);
        }

        public ICommand GeneratorCommand(
            OpenApiModel openApiModel, Action onSuccess,
            Action<Exception> onError
        )
        {
            return new GenerateCommand(_appController, _logger, openApiModel, onSuccess, onError);
        }

    }
}
