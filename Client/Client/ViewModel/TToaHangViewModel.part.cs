using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TToaHangViewModel : BaseViewModel<TToaHangDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = false;
        }
    }
}
