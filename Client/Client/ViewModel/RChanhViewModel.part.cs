using Client.Abstraction;
using DTO;

namespace Client.ViewModel
{
    public partial class RChanhViewModel : BaseViewModel<RChanhDto>
    {
        partial void InitFilterPartial()
        {
            _MaBaiXeFilter.IsSorted = true;
            _MaBaiXeFilter.SortPropertyName = "MaBaiXeNavigation.DiaDiemBaiXe";
            _TenChanhFilter.IsSorted = true;
        }
    }
}
