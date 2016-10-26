using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RLoaiHangViewModel : Abstraction.BaseViewModel<RLoaiHangDto>
    {
        public RLoaiHangViewModel() : base()
        {
            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RLoaiHangDto.Ma), typeof(int)));
            AddHeaderFilter(new HeaderTextFilterModel("Ten Loai", nameof(RLoaiHangDto.TenLoai), typeof(string)));
            AddHeaderFilter(new HeaderTextFilterModel("Hang Nha", nameof(RLoaiHangDto.HangNhaLam), typeof(bool)));
        }
    }
}
