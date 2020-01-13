using Terminal.Gui;

namespace client_generator.App
{
    public interface IAppController
    {

        void ChangeWindow(Window newWindow);

        void ExitApp();

        Window GetCurrentWindow();

    }
}
