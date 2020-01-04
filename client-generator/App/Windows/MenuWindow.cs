using System;
using client_generator.App.Commands;
using Terminal.Gui;

namespace client_generator.App.Windows
{
    public class MenuWindow : Window
    {

        private readonly ICommand _exitCommand = new ExitAppCommand();

        private readonly ICommand _selectFileCommand;

        private FileSystemEntry _file;


        private Action _clear;


        public MenuWindow() : base(new Rect(0, 0, Application.Top.Frame.Width, Application.Top.Frame.Height),
            "Code Generator - Menu")
        {
            _selectFileCommand = new SelectFileCommand(FileWasSelected);

            ShowMenuWithoutFile();
        }

        void ShowMenuWithoutFile()
        {
            RemoveAll();

            var loadButton = new Button("Load the openApi.json")
                {X = Pos.Center(), Y = Pos.Percent(20), Clicked = _selectFileCommand.Execute};
            var exitButton = new Button("Exit")
                {X = Pos.Center(), Y = Pos.Bottom(loadButton), Clicked = _exitCommand.Execute};
            _clear = () =>
            {
                Remove(loadButton);
                Remove(exitButton);
            };
            Add(loadButton, exitButton);
        }

        void ShowMenuWithFile()
        {
            _clear.Invoke();

            // var currentFileLabel = new Label(1,1, $"Selected file: {_file.FileName}");
            //
            var checkButton = new Button("Check current file.")
                {X = Pos.Center(), Y = Pos.Percent(20)};
            var deserializeButton = new Button("Deserialize selected file.")
                {X = Pos.Center(), Y = Pos.Bottom(checkButton)};
            var exitButton = new Button("Exit")
                {X = Pos.Center(), Y = Pos.Bottom(deserializeButton), Clicked = _exitCommand.Execute};
            
            Add(checkButton, deserializeButton, exitButton);
        }


        void FileWasSelected(FileSystemEntry file)
        {
            _file = file;
            ShowMenuWithFile();
        }

    }
}
