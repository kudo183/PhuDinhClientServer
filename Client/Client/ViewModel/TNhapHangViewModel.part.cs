using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TNhapHangViewModel : BaseViewModel<TNhapHangDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = nameof(TNhapHangDto.Ngay),
                IsAscending = false
            });
        }
    }
}
