using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RKhoHangViewModel : Abstraction.BaseViewModel<RKhoHangDto>
    {
        public RKhoHangViewModel() : base()
        {
            HeaderFilters.Add(new HeaderTextFilterModel("Ma", nameof(RKhoHangDto.Ma), typeof(int)));
            HeaderFilters.Add(new HeaderTextFilterModel("Ten kho", nameof(RKhoHangDto.TenKho), typeof(string)));
            HeaderFilters.Add(new HeaderCheckFilterModel("Trang thai", nameof(RKhoHangDto.TrangThai), typeof(bool)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }
    }
}
