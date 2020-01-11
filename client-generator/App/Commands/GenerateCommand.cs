using System;
using client_generator.Generators;
using client_generator.Models;

namespace client_generator.App.Commands
{
    class GenerateCommand : ICommand
    {

        private readonly OpenApiModel _openApiModel;

        private readonly Action _onSuccess;

        private readonly Action<Exception> _onError;

        public GenerateCommand(OpenApiModel openApiModel, Action onSuccess, Action<Exception> onError)
        {
            _openApiModel = openApiModel;
            _onSuccess = onSuccess;
            _onError = onError;
        }

        public void Execute()
        {
            var generator = new Generator();
            try
            {
                generator.Generate(_openApiModel);
                _onSuccess.Invoke();
            }
            catch (Exception e)
            {
                _onError.Invoke(e);
            }
        }

    }
}
