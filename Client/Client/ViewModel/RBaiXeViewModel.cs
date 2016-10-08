using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RBaiXeViewModel : BaseViewModel<RBaiXeDto>
    {
        public RBaiXeViewModel() : base()
        {
            HeaderFilters.Add(new HeaderTextFilterModel("Ma", "Ma", typeof(int)));
            HeaderFilters.Add(new HeaderTextFilterModel("Dia Diem", "DiaDiemBaiXe", typeof(string)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }
    }
}
