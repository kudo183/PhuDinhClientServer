using SimpleDataGrid.ViewModel;
using System.Collections.Generic;

namespace Client.Abstraction
{
    public interface IBaseViewModel
    {
        bool IsValid { get; set; }
        void Load();
        void Save();
        List<HeaderFilterBaseModel> HeaderFilters { get; set; }
        System.Action<int> ActionSelectedIndexChanged { get; set; }
        IReadOnlyList<T> GetEntities<T>();
    }
}
