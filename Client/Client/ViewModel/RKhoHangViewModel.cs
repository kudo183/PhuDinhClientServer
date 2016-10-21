using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RKhoHangViewModel : Abstraction.BaseViewModel<RKhoHangDto>
    {
        public RKhoHangViewModel() : base()
        {
            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RKhoHangDto.Ma), typeof(int)));
            AddHeaderFilter(new HeaderTextFilterModel("Ten kho", nameof(RKhoHangDto.TenKho), typeof(string)));
            AddHeaderFilter(new HeaderCheckFilterModel("Trang thai", nameof(RKhoHangDto.TrangThai), typeof(bool)));
        }
    }
}
