namespace client_generator.Generators
{
    public class GeneratorSettings
    {

        public SchemeGeneratePlace SchemePlace { get; set; } = SchemeGeneratePlace.WithCode;

        public string ServerUrl { get; set; } = "http://localhost";

        public string ClientFileName { get; set; } = "client";

        public string TypesFileName { get; set; } = "types";

    }
}
