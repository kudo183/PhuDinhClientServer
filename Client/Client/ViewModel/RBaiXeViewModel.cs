using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RBaiXeViewModel : BaseViewModel<RBaiXeDto>
    {
        public RBaiXeViewModel() : base()
        {
            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RBaiXeDto.Ma), typeof(int)));
            AddHeaderFilter(new HeaderTextFilterModel("Dia Diem", nameof(RBaiXeDto.DiaDiemBaiXe), typeof(string)));
        }
    }
}
