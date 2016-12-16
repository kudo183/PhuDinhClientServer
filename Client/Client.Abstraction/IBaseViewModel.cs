using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace Client.Abstraction
{
    public interface IBaseViewModel : INotifyPropertyChanged
    {
        bool IsValid { get; set; }
        void Load();
        void Save();
        void LoadReferenceData();
        string Msg { get; set; }
        object ParentItem { get; set; }
        object SelectedItem { get; set; }
        List<HeaderFilterBaseModel> HeaderFilters { get; set; }
        System.Action<object> ActionSelectedValueChanged { get; set; }
    }
}
