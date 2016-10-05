using System;
using System.Windows.Controls;

namespace Client.Abstraction
{
    public interface IBaseView
    {
        event EventHandler AfterSave;
        event EventHandler AfterCancel;

        event EventHandler MoveFocusToNextView;
        event SelectionChangedEventHandler SelectionChanged;
    }
}
