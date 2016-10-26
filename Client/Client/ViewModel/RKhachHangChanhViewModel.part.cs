using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RKhachHangChanhViewModel : BaseViewModel<RKhachHangChanhDto>
    {
        partial void InitFilterPartial()
        {
            _khachHangFilter = new HeaderComboBoxFilterModel(
                "Khach Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangChanhDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenKhachHang),
                nameof(RKhachHangDto.Ma));
            _khachHangFilter.AddCommand = new SimpleCommand("KhachHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RKhachHangView(), "Khach Hang", ReferenceDataManager<RKhachHangDto>.Instance.Load)
            );
            _khachHangFilter.ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            _chanhFilter = new HeaderComboBoxFilterModel(
                "Chanh", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangChanhDto.MaChanh),
                typeof(int),
                nameof(RChanhDto.TenChanh),
                nameof(RChanhDto.Ma));
            _chanhFilter.AddCommand = new SimpleCommand("ChanhAddCommand",
                () =>
                {
                    base.ProccessHeaderAddCommand(
                new View.RChanhView(), "Chanh", ReferenceDataManager<RChanhDto>.Instance.Load);
                },
                () => true
            );
            _chanhFilter.ItemSource = ReferenceDataManager<RChanhDto>.Instance.Get();
        }
    }
}
