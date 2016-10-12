using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RNuocViewModel : Abstraction.BaseViewModel<RNuocDto>
    {
        public RNuocViewModel() : base()
        {
            HeaderFilters.Add(new HeaderTextFilterModel("Ma", nameof(RNuocDto.Ma), typeof(int)));
            HeaderFilters.Add(new HeaderTextFilterModel("Ten nuoc", nameof(RNuocDto.TenNuoc), typeof(string)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }
    }
}
