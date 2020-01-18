using System;
using client_generator.App.Windows.MenuWindowStates;
using client_generator.Models;
using Newtonsoft.Json;
using Terminal.Gui;

namespace client_generator.App.Commands
{
    public interface ICommandsProvider
    {

        ICommand ExitCommand();

        ICommand DeserializationCommand(
            FileSystemEntry file,
            JsonSerializerSettings deserializationSettings,
            Action<OpenApiModel> onDeserialization,
            Action<Exception> onError
        );

        ICommand ShowPopupWindowCommand(
            PopupWindow popupWindow,
            Action<object> receiver,
            Window current
        );

        ICommand GeneratorCommand(
            OpenApiModel openApiModel, Action onSuccess,
            Action<Exception> onError
        );

    }
}