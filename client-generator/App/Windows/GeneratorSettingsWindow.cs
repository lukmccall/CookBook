using System;
using client_generator.Generators;
using Terminal.Gui;

namespace client_generator.App.Windows
{
    public class GeneratorSettingsWindow : Window
    {

        private readonly GeneratorSettings _settings;

        private readonly Action _onDone;

        private readonly TextField _serverUrl;

        private readonly TextField _clientFileName;

        private readonly TextField _typesFileName;

        private readonly RadioGroup _schemaPlace;

        public GeneratorSettingsWindow(Action onDone, GeneratorSettings settings) : base(
            "Code Generator - Generator Settings")
        {
            _settings = settings;
            _onDone = onDone;

            var urlLabel = new Label(1, 2, "Server url:");
            _serverUrl = new TextField(_settings.ServerUrl)
            {
                X = 1,
                Y = Pos.Bottom(urlLabel)
            };


            var clientFileLabel = new Label(1, 5, "Client file name:");
            _clientFileName = new TextField(_settings.ClientFileName)
            {
                X = 1,
                Y = Pos.Bottom(clientFileLabel)
            };

            var typesFileLabel = new Label(1, 8, "Types file name:");
            _typesFileName = new TextField(_settings.TypesFileName)
            {
                X = 1,
                Y = Pos.Bottom(typesFileLabel)
            };

            var g1Label = new Label(1, 11, "Types location:");
            var g1Holder = new View
            {
                Y = Pos.Bottom(g1Label),
                X = 1,
                Width = Dim.Fill(1),
                Height = 4
            };
            _schemaPlace = new RadioGroup(new[] {"WithCode", "SeparatedFile", "AllSeparated"},
                (int) _settings.SchemePlace);
            g1Holder.Add(_schemaPlace);

            var exitButton = new Button("Ok")
            {
                X = Pos.Center(),
                Y = Pos.Percent(90),
                Clicked = Clicked
            };

            Add(urlLabel, _serverUrl,
                clientFileLabel, _clientFileName,
                typesFileLabel, _typesFileName,
                g1Label, g1Holder,
                exitButton);
        }

        private void Clicked()
        {
            _settings.ServerUrl = _serverUrl.Text.ToString() ?? "";
            _settings.ClientFileName = _clientFileName.Text.ToString() ?? "client";
            _settings.TypesFileName = _typesFileName.Text.ToString() ?? "types";
            _settings.SchemePlace = (SchemeGeneratePlace) _schemaPlace.Selected;
            _onDone.Invoke();
        }

    }
}
