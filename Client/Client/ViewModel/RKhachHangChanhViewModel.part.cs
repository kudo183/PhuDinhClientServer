using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class RKhachHangChanhViewModel : BaseViewModel<RKhachHangChanhDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = "MaKhachHangNavigation.TenKhachHang",
                IsAscending = true
            });
        }
    }
}
