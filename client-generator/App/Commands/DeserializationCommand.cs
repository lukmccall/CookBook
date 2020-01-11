using System;
using System.IO;
using client_generator.Models;
using client_generator.OpenApi._3._0._1.Deserializer;
using Newtonsoft.Json;

namespace client_generator.App.Commands
{
    class DeserializationCommand : ICommand
    {

        private readonly FileSystemEntry _file;

        private readonly JsonSerializerSettings _deserializationSettings;

        private readonly Action<OpenApiModel> _onDeserialization;

        private readonly Action<Exception> _onError;

        public DeserializationCommand(FileSystemEntry file, JsonSerializerSettings deserializationSettings, Action<OpenApiModel> onDeserialization,
            Action<Exception> onError)
        {
            _file = file;
            _deserializationSettings = deserializationSettings;
            _onDeserialization = onDeserialization;
            _onError = onError;
        }

        public void Execute()
        {
            try
            {
                var jsonString = File.ReadAllText(Path.Join(_file.ParentDirectory, _file.FileName));
                var openApiModel = new Deserializer301(_deserializationSettings).Deserialize(jsonString);

                _onDeserialization(openApiModel);
            }
            catch (Exception e)
            {
                _onError(e);
            }
        }

    }
}
