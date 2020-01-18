using System;
using client_generator.Generators;
using logger;
using Terminal.Gui;

namespace client_generator.App
{
    public class AppController : IAppController
    {

        private static readonly AppController AppControllerInstance = new AppController();

        private ILogger _logger;

        private Window _currentWindow;

        private Toplevel _toplevel;

        private AppController()
        {
        }

        public GeneratorTemplate Generator { get; private set; }

        public static AppController Instance()
        {
            return AppControllerInstance;
        }

        public static ILogger GetLogger()
        {
            return AppControllerInstance._logger;
        }

        public void StartWindow(Window window, GeneratorTemplate generator, ILogger logger)
        {
            _logger = logger;
            Generator = generator;

            _logger.Info("Initialization gui...");
            _toplevel = new Toplevel
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            _currentWindow = window;
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
