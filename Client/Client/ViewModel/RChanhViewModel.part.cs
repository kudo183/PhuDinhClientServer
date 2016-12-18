using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class RChanhViewModel : BaseViewModel<RChanhDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = "MaBaiXeNavigation.DiaDiemBaiXe",
                IsAscending = true
            });
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = nameof(RChanhDto.TenChanh),
                IsAscending = true
            });
        }
    }
}
