using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class RKhachHangViewModel : BaseViewModel<RKhachHangDto>
    {
        partial void InitFilterPartial()
        {
            _TenKhachHangFilter.IsSorted = true;
        }

        partial void ProcessNewAddedDtoPartial(RKhachHangDto dto)
        {
            dto.KhachRieng = false;
        }
    }
}
