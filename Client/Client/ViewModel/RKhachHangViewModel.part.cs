using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class RKhachHangViewModel : BaseViewModel<RKhachHangDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = nameof(RKhachHangDto.TenKhachHang),
                IsAscending = true
            });
        }

        partial void ProcessNewAddedDtoPartial(RKhachHangDto dto)
        {
            dto.KhachRieng = false;
        }
    }
}
