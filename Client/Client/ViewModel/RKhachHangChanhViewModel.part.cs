using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class RKhachHangChanhViewModel : BaseViewModel<RKhachHangChanhDto>
    {
        partial void InitFilterPartial()
        {
            _MaKhachHangFilter.IsSorted = true;
            _MaKhachHangFilter.SortPropertyName = "MaKhachHangNavigation.TenKhachHang";
        }
    }
}
