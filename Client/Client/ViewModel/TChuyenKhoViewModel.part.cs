using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TChuyenKhoViewModel : BaseViewModel<TChuyenKhoDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = false;
        }
    }
}
