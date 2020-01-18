using client_generator.App;
using client_generator.App.Commands;
using client_generator.App.Windows;
using client_generator.Deserializer;
using client_generator.Generators;
using client_generator.Templates;
using client_generator.Templates.Clients;
using client_generator.Templates.Endpoints;
using client_generator.Templates.Parameters;
using client_generator.Templates.Requests;
using client_generator.Templates.Responses;
using client_generator.Templates.Schemes;
using logger;
using logger.LogStrategies;
using Terminal.Gui;

namespace client_generator
{
    internal static class Program
    {

        private static void Main()
        {
            var generator = SetUpGenerator();
            var logger = SetUpLogger();

            VersionedDeserializers.RegisterFromAssembly(typeof(Program).Assembly);

            Application.Init();

            var commandProvider = new CommandsProvider(AppController.Instance(), logger);
            var menu = new MenuWindow(commandProvider);
            AppController.Instance().StartWindow(menu, generator, logger);
        }

        private static GeneratorTemplate SetUpGenerator()
        {
            var templateFactory = new TemplatesFactory.TemplateFactoryBuilder()
                .SetClientTemplateFactory(new ClientTemplateFactory())
                .SetParameterTemplateFactory(new ParameterTemplateFactory())
                .SetRequestTemplateFactory(new RequestTemplateFactory())
                .SetResponseTemplateFactory(new ResponseTemplateFactory())
                .SetEndpointTemplateFactory(new EndpointTemplateFactory())
                .SetClassSchemaTemplateFactory(new ClassSchemaTemplateFactory())
                .Build();
            var context = new GeneratorContext(templateFactory);
            return new Generator(context);
        }

        private static ILogger SetUpLogger()
        {
            return new LoggerFacade<RawLogger>(new LoggerSettings
            {
                LogLevel = LogLevel.Debug | LogLevel.Info | LogLevel.Warn | LogLevel.Error | LogLevel.Fatal,
                DefaultLogStrategy = new FileLogStrategy("logs.log")
            });
        }

    }
}
