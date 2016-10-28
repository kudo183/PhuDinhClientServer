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
            _MaDonHangFilter = new HeaderComboBoxFilterModel(
                "Don Hang", HeaderComboBoxFilterModel.TextFilter,
                nameof(TChiTietDonHangDto.MaDonHang), typeof(int), nameof(TDonHangDto.Ma), nameof(TDonHangDto.Ma));
            _MaDonHangFilter.AddCommand = new SimpleCommand("DonHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.TDonHangView(), "Don Hang", ReferenceDataManager<TDonHangDto>.Instance.Load)
            );
            _MaDonHangFilter.ItemSource = ReferenceDataManager<TDonHangDto>.Instance.Get();

            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                "Mat Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietDonHangDto.MaMatHang), typeof(int), nameof(TMatHangDto.TenMatHang), nameof(TMatHangDto.Ma));
            _MaMatHangFilter.AddCommand = new SimpleCommand("MatHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.TMatHangView(), "Mat Hang", ReferenceDataManager<TMatHangDto>.Instance.Load)
            );
            _MaMatHangFilter.ItemSource = ReferenceDataManager<TMatHangDto>.Instance.Get();
        }
    }
}
