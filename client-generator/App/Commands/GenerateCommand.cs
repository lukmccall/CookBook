using System;
using client_generator.Models;

namespace client_generator.App.Commands
{
    internal class GenerateCommand : ICommand
    {

        private readonly Action<Exception> _onError;

        private readonly Action _onSuccess;

        private readonly OpenApiModel _openApiModel;

        public GenerateCommand(OpenApiModel openApiModel, Action onSuccess,
            Action<Exception> onError)
        {
            _openApiModel = openApiModel;
            _onSuccess = onSuccess;
            _onError = onError;
        }

        public void Execute()
        {
            try
            {
                AppController.GetLogger().Info("Generate client.");
                AppController.Instance().Generator.Generate(_openApiModel);
                _onSuccess.Invoke();
            }
            catch (Exception e)
            {
                _onError.Invoke(e);
            }
        }

    }
}
