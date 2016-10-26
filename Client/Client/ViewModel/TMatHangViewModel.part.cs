using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class TMatHangViewModel : BaseViewModel<TMatHangDto>
    {
        partial void InitFilterPartial()
        {
            _loaiHangFilter = new HeaderComboBoxFilterModel(
                "Loai Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TMatHangDto.MaLoai), typeof(int), nameof(RLoaiHangDto.TenLoai), nameof(RLoaiHangDto.Ma));
            _loaiHangFilter.AddCommand = new SimpleCommand("LoaiHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RLoaiHangView(), "Loai Hang", ReferenceDataManager<RLoaiHangDto>.Instance.Load)
            );
            _loaiHangFilter.ItemSource = ReferenceDataManager<RLoaiHangDto>.Instance.Get();
        }
    }
}
