using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public class RLoaiHangViewModel : Abstraction.BaseViewModel<RLoaiHangDto>
    {
        public RLoaiHangViewModel() : base()
        {
            HeaderFilters.Add(new HeaderTextFilterModel("Ma", nameof(RLoaiHangDto.Ma), typeof(int)));
            HeaderFilters.Add(new HeaderTextFilterModel("Ten Loai", nameof(RLoaiHangDto.TenLoai), typeof(string)));
            HeaderFilters.Add(new HeaderTextFilterModel("Hang Nha", nameof(RLoaiHangDto.HangNhaLam), typeof(bool)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }
    }
}
