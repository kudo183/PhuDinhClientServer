using SimpleDataGrid.ViewModel;
using System.Collections.Generic;

namespace Client.Abstraction
{
    public interface IBaseViewModel
    {
        bool IsValid { get; set; }
        void Load();
        void Save();
        void LoadReferenceData();
        List<HeaderFilterBaseModel> HeaderFilters { get; set; }
        System.Action<object> ActionSelectedValueChanged { get; set; }
    }
}
