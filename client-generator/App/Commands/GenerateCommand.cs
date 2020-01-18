using System;
using client_generator.Models;
using logger;

namespace client_generator.App.Commands
{
    internal class GenerateCommand : ICommand
    {

        private readonly Action<Exception> _onError;

        private readonly Action _onSuccess;

        private readonly AppController _controller;

        private readonly ILogger _logger;

        private readonly OpenApiModel _openApiModel;

        public GenerateCommand(AppController controller, ILogger logger,OpenApiModel openApiModel, Action onSuccess,
            Action<Exception> onError)
        {
            _controller = controller;
            _logger = logger;
            _openApiModel = openApiModel;
            _onSuccess = onSuccess;
            _onError = onError;
        }

        public void Execute()
        {
            try
            {
                _logger.Info("Generate client.");
                _controller.Generator.Generate(_openApiModel);
                _onSuccess.Invoke();
            }
            catch (Exception e)
            {
                _onError.Invoke(e);
            }
        }

    }
}
