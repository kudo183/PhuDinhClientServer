using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TNhapHangViewModel : BaseViewModel<TNhapHangDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TNhapHangDto dto)
        {
            if (dto.MaKhoHang == 0)
            {
                dto.MaKhoHang = Settings.Instance.DefaultMaKhoHang;
            }
        }
    }
}
