using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RKhachHangViewModel : BaseViewModel<RKhachHangDto>
    {
        partial void InitFilterPartial()
        {
            _TenKhachHangFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Ascending;
        }

        partial void ProcessNewAddedDtoPartial(RKhachHangDto dto)
        {
            dto.KhachRieng = false;
        }
    }
}
