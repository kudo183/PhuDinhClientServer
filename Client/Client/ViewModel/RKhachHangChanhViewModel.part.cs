using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RKhachHangChanhViewModel : BaseViewModel<RKhachHangChanhDto>
    {
        partial void InitFilterPartial()
        {
            _MaKhachHangFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Ascending;
            _MaKhachHangFilter.SortPropertyName = "MaKhachHangNavigation.TenKhachHang";
        }
    }
}
