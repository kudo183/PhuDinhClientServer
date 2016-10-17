using SimpleDataGrid;
using System;

namespace Client.Abstraction
{
    public interface IBaseView
    {
        IBaseViewModel ViewModel { get; set; }
        EditableGridView GridView { get; set; }
        event EventHandler AfterSave;
        event EventHandler AfterCancel;

        Action ActionMoveFocusToNextView { get; set; }
    }
}
