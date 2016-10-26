using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RNuocViewModel : Abstraction.BaseViewModel<RNuocDto>
    {
        public RNuocViewModel() : base()
        {
            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RNuocDto.Ma), typeof(int)));
            AddHeaderFilter(new HeaderTextFilterModel("Ten nuoc", nameof(RNuocDto.TenNuoc), typeof(string)));
        }
    }
}
