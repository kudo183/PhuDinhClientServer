using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RNuocViewModel : Abstraction.BaseViewModel<DTO.RNuocDto>
    {
        public RNuocViewModel() : base()
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
