using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TChiPhiViewModel : BaseViewModel<TChiPhiDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = nameof(TChiPhiDto.Ngay),
                IsAscending = false
            });
        }
    }
}
