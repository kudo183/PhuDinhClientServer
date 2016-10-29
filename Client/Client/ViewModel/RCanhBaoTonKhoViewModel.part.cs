using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RCanhBaoTonKhoViewModel
    {
        partial void InitFilterPartial()
        {
            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                "Mat Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RCanhBaoTonKhoDto.MaMatHang), typeof(int), nameof(TMatHangDto.TenMatHang), nameof(TMatHangDto.Ma));
            _MaMatHangFilter.AddCommand = new SimpleCommand("MatHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.TMatHangView(), "Mat Hang", ReferenceDataManager<TMatHangDto>.Instance.Load)
            );
            _MaMatHangFilter.ItemSource = ReferenceDataManager<TMatHangDto>.Instance.Get();

            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                "Kho Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RCanhBaoTonKhoDto.MaKhoHang),
                typeof(int),
                nameof(RKhoHangDto.TenKho),
                nameof(RKhoHangDto.Ma));
            _MaKhoHangFilter.AddCommand = new SimpleCommand("KhoHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                  new View.RKhoHangView(), "Kho Hang", ReferenceDataManager<RKhoHangDto>.Instance.Load)
            );
            _MaKhoHangFilter.ItemSource = ReferenceDataManager<RKhoHangDto>.Instance.Get();
        }
    }
}
