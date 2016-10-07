using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RBaiXeViewModel : Abstraction.BaseViewModel<DTO.RBaiXeDto>
    {
        public RBaiXeViewModel(Abstraction.IDataService<DTO.RBaiXeDto> dataService)
            : base(dataService)
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
