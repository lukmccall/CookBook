using System;
using Terminal.Gui;

namespace client_generator.App
{
    public class AppController
    {

        private static readonly AppController _appController = new AppController();

        private Window _currentWindow;
        
        private Toplevel _toplevel;

        private AppController()
        {
        }

        public static AppController Instance()
        {
            return _appController;
        }

        public void InitApp<T>() where T : Window, new()
        {
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

            Application.Run(_toplevel);
        }

        public void ChangeWindow(Window newWindow)
        {
            if (_toplevel == null)
            {
                throw new InvalidOperationException("Couldn't change window. TopLevel view doesn't exist.");
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
        }

        public Window GetCurrentWindow()
        {
            return _currentWindow;
        }

    }
}
