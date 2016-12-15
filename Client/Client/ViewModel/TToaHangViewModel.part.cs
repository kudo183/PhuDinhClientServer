using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TToaHangViewModel : BaseViewModel<TToaHangDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = nameof(TToaHangDto.Ngay),
                IsAscending = false
            });
        }
    }
}
