using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TChuyenHangViewModel : BaseViewModel<TChuyenHangDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = nameof(TChuyenHangDto.Ngay),
                IsAscending = false
            });
        }
    }
}
