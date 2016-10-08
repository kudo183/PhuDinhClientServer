using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RKhoHangViewModel : Abstraction.BaseViewModel<DTO.RKhoHangDto>
    {
        public RKhoHangViewModel() : base()
        {
            HeaderFilters.Add(new HeaderTextFilterModel("Ma", "Ma", typeof(int)));
            HeaderFilters.Add(new HeaderTextFilterModel("Ten kho", "TenKho", typeof(string)));
            HeaderFilters.Add(new HeaderCheckFilterModel("Trang thai", "TrangThai", typeof(bool)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }
    }
}
