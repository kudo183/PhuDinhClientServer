using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class TChuyenHangViewModel : BaseViewModel<TChuyenHangDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = false;
        }
    }
}
