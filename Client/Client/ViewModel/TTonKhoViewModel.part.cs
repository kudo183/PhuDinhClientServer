using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TTonKhoViewModel : BaseViewModel<TTonKhoDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = false;
        }
    }
}
