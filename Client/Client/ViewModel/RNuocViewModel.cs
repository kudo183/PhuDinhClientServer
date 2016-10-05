using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RNuocViewModel : Abstraction.BaseViewModel<DTO.RNuocDto>
    {
        public RNuocViewModel(Abstraction.IDataService<DTO.RNuocDto> dataService)
            : base("RNuocViewModel", dataService)
        {
            HeaderFilters.Add(new HeaderTextFilterModel("Ma", "Ma", typeof(int)));
            HeaderFilters.Add(new HeaderTextFilterModel("Ten nuoc", "TenNuoc", typeof(string)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }
    }
}
