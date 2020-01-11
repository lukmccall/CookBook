using System;
using System.IO;
using client_generator.Deserializer;
using client_generator.Models;
using Newtonsoft.Json;

namespace client_generator.App.Commands
{
    class DeserializationCommand : ICommand
    {

        private readonly FileSystemEntry _file;

        private readonly JsonSerializerSettings _deserializationSettings;

        private readonly Action<OpenApiModel> _onDeserialization;

        private readonly Action<Exception> _onError;

        public DeserializationCommand(FileSystemEntry file, JsonSerializerSettings deserializationSettings,
            Action<OpenApiModel> onDeserialization,
            Action<Exception> onError)
        {
            _file = file;
            _deserializationSettings = deserializationSettings;
            _onDeserialization = onDeserialization;
            _onError = onError;
        }

        public void Execute()
        {
            
                var path = Path.Join(_file.ParentDirectory, _file.FileName);
                var openApiModel = VersionedDeserializers.Instance().DeserializeFile(path, _deserializationSettings);
                
                _onDeserialization(openApiModel);
            
        }

    }
}
