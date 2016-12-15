using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TTonKhoViewModel : BaseViewModel<TTonKhoDto>
    {
        partial void InitFilterPartial()
        {
            OrderOptions.Add(new QueryBuilder.OrderByExpression.OrderOption()
            {
                PropertyPath = nameof(TTonKhoDto.Ngay),
                IsAscending = false
            });
        }
    }
}
