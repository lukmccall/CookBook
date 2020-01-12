using System;
using client_generator.Generators;
using logger;
using logger.LogStrategies;
using Terminal.Gui;

namespace client_generator.App
{
    public class AppController
    {

        private static readonly AppController AppControllerInstance = new AppController();

        private readonly ILogger _logger = new LoggerFacade<RawLogger>(new LoggerSettings
        {
            LogLevel = LogLevel.Debug | LogLevel.Info | LogLevel.Warn | LogLevel.Error | LogLevel.Fatal,
            DefaultLogStrategy = new FileLogStrategy("logs.log")
        });

        private Window _currentWindow;

        private Toplevel _toplevel;

        private AppController()
        {
        }

        public GeneratorTemplate Generator { get; } = new Generator();

        public static AppController Instance()
        {
            return AppControllerInstance;
        }

        public static ILogger GetLogger()
        {
            return AppControllerInstance._logger;
        }

        public void InitApp<T>() where T : Window, new()
        {
            _logger.Info("Initialization...");
            Application.Init();
            _toplevel = new Toplevel
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            _currentWindow = new T();
            _toplevel.Add(_currentWindow);

            _logger.Info("Star up...");
            Application.Run(_toplevel);
        }

        public void ChangeWindow(Window newWindow)
        {
            if (_toplevel == null)
            {
                var errorMessage = "Couldn't change window. TopLevel view doesn't exist.";
                _logger.Fatal(errorMessage);
                throw new InvalidOperationException(errorMessage);
            }

            _toplevel.RemoveAll();
            _toplevel.Add(newWindow);
            _currentWindow = newWindow;
            _toplevel.LayoutSubviews();
            _toplevel.FocusFirst();
        }

        public void ExitApp()
        {
            Application.RequestStop();
            _logger.Info("App stop correctly.");
        }

        public Window GetCurrentWindow()
        {
            return _currentWindow;
        }

    }
}
