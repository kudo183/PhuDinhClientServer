using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RChanhViewModel : BaseViewModel<RChanhDto>
    {
        partial void InitFilterPartial()
        {
            _MaBaiXeFilter.IsSorted =  HeaderFilterBaseModel.SortDirection.Ascending;
            _MaBaiXeFilter.SortPropertyName = "MaBaiXeNavigation.DiaDiemBaiXe";
            _TenChanhFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Ascending;
        }
    }
}
