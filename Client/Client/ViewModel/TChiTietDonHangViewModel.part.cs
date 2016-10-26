using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class TChiTietDonHangViewModel : BaseViewModel<TChiTietDonHangDto>
    {
        partial void InitFilterPartial()
        {
            _matHangFilter = new HeaderComboBoxFilterModel(
                "Mat Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietDonHangDto.MaMatHang), typeof(int), nameof(TMatHangDto.TenMatHang), nameof(TMatHangDto.Ma));
            _matHangFilter.AddCommand = new SimpleCommand("MatHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.TMatHangView(), "Mat Hang", ReferenceDataManager<TMatHangDto>.Instance.Load)
            );
            _matHangFilter.ItemSource = ReferenceDataManager<TMatHangDto>.Instance.Get();
        }
    }
}
