using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChuyenHangViewModel : BaseViewModel<TChuyenHangDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;
        }
    }
}
