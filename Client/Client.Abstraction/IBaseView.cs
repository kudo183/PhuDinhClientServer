using SimpleDataGrid;
using System;

namespace Client.Abstraction
{
    public interface IBaseView
    {
        IBaseViewModel ViewModel { get; set; }
        EditableGridView GridView { get; set; }
        Action ActionAfterSave { get; set; }
        Action ActionAfterLoad { get; set; }
        Action ActionMoveFocusToNextView { get; set; }
    }
}
