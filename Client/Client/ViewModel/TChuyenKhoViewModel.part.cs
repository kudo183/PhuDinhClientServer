using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TChuyenKhoViewModel : BaseViewModel<TChuyenKhoDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = nameof(TChuyenKhoDto.Ngay),
                IsAscending = false
            });
        }
    }
}
