using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using client_generator.App;
using client_generator.Deserializer.Attributes;
using client_generator.Extensions;
using client_generator.Models;
using Newtonsoft.Json;

namespace client_generator.Deserializer
{
    public class VersionedDeserializers
    {

        private static readonly VersionedDeserializers VersionedDeserializersInstance = new VersionedDeserializers();

        private readonly Dictionary<string, IDeserializer>
            _deserializers = new Dictionary<string, IDeserializer>();

        private VersionedDeserializers()
        {
        }

        public static VersionedDeserializers Instance()
        {
            return VersionedDeserializersInstance;
        }

        public static void RegisterFromAssembly(Assembly assembly)
        {
            var iterator = assembly.CreateOpenApiDeserializerAssemblyIterator();
            while (iterator.MoveNext())
            {
                var current = iterator.Current;

                if (current == null)
                {
                    AppController.GetLogger().Warn("OpenApiDeserializer returns null. Skipping this element.");
                    continue;
                }

                var version = current.GetCustomAttribute<OpenApiDeserializer>()?.Version;
                if (string.IsNullOrEmpty(version))
                {
                    AppController.GetLogger()
                        .Warn("OpenApiDeserializer returns element. without version. Skipping this element.");
                    continue;
                }

                try
                {
                    var instance = (IDeserializer) Activator.CreateInstance(current);

                    if (instance == null)
                    {
                        AppController.GetLogger()
                            .Error($"Couldn't create {current}. Activator returns null. Skipping this element.");
                        continue;
                    }

                    Instance().Register(version, instance);
                }
                catch (Exception e)
                {
                    AppController.GetLogger()
                        .Error($"Couldn't create {current}, due {e.Message}. Skipping this element.");
                }
            }
        }

        public OpenApiModel DeserializeFile(string path, JsonSerializerSettings settings)
        {
            var jsonString = File.ReadAllText(path);
            var versionGetter = JsonConvert.DeserializeObject<VersionGetter>(jsonString, settings);
            if (versionGetter.Version == null)
            {
                throw new InvalidDataException("Couldn't parse version.");
            }

            var deserializer = _deserializers.GetValueOrDefault(versionGetter.Version, null);
            if (deserializer == null)
            {
                throw new InvalidOperationException(
                    $"Missing deserializer. Unsupported version {versionGetter.Version}.");
            }

            deserializer.SetSettings(settings);
            return deserializer.Deserialize(jsonString);
        }

        public void Register(string version, IDeserializer deserializer)
        {
            _deserializers.Add(version, deserializer);
        }

    }
}
