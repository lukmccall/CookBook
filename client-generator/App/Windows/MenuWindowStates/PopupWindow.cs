using System;
using NStack;
using Terminal.Gui;

namespace client_generator.App.Windows.MenuWindowStates
{
    public abstract class PopupWindow : Window
    {

        protected Action<object> OnExit;

        protected PopupWindow(ustring title = null) : base(title)
        {
        }

        public void SetActionReceiver(Action<object> action)
        {
            OnExit = action;
        }

    }
}
