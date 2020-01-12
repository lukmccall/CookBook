using System;
using Newtonsoft.Json;
using Terminal.Gui;

namespace client_generator.App.Windows
{
    public class JsonSettingsWindow : Window
    {

        private readonly RadioGroup _constructorHandlingOptions;

        private readonly JsonSerializerSettings _jsonSerializerSettings;

        private readonly RadioGroup _missingMemberHandlingOptions;

        private readonly RadioGroup _nullValueHandlingOptions;

        private readonly Action _onDone;

        public JsonSettingsWindow(Action onDone, JsonSerializerSettings jsonSerializerSettings) : base(
            "Code Generator - Deserialization settings")
        {
            _onDone = onDone;
            _jsonSerializerSettings = jsonSerializerSettings;

            var g1Label = new Label(1, 1, "NullValueHandling:");
            var g1Holder = new View
            {
                Y = Pos.Bottom(g1Label),
                X = 1,
                Width = Dim.Fill(1),
                Height = 3
            };
            _nullValueHandlingOptions = new RadioGroup(new[] {"Include", "Ignore"},
                (int) _jsonSerializerSettings.NullValueHandling);
            g1Holder.Add(_nullValueHandlingOptions);

            var g2Label = new Label(1, 5, "ConstructorHandling:");
            var g2Holder = new View
            {
                X = 1,
                Y = Pos.Bottom(g2Label),
                Width = Dim.Fill(1),
                Height = 3
            };
            _constructorHandlingOptions = new RadioGroup(new[] {"	Default", "	AllowNonPublicDefaultConstructor"},
                (int) _jsonSerializerSettings.ConstructorHandling);
            g2Holder.Add(_constructorHandlingOptions);

            var g3Label = new Label(1, 9, "MissingMemberHandling:");
            var g3Holder = new View
            {
                X = 1,
                Y = Pos.Bottom(g3Label),
                Width = Dim.Fill(1),
                Height = 3
            };
            _missingMemberHandlingOptions = new RadioGroup(new[] {"Ignore", "Error"},
                (int) _jsonSerializerSettings.MissingMemberHandling);
            g3Holder.Add(_missingMemberHandlingOptions);


            var exitButton = new Button("Back")
                {X = Pos.Center(), Y = Pos.Percent(80), Clicked = ProcessInput};


            Add(g1Label, g1Holder, g2Label, g2Holder, g3Label, g3Holder, exitButton);
        }

        private void ProcessInput()
        {
            _jsonSerializerSettings.NullValueHandling = (NullValueHandling) _nullValueHandlingOptions.Selected;
            _jsonSerializerSettings.ConstructorHandling = (ConstructorHandling) _constructorHandlingOptions.Selected;
            _jsonSerializerSettings.MissingMemberHandling =
                (MissingMemberHandling) _missingMemberHandlingOptions.Selected;

            _onDone.Invoke();
        }

    }
}
