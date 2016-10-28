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
            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                "Khach Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangChanhDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenKhachHang),
                nameof(RKhachHangDto.Ma));
            _MaKhachHangFilter.AddCommand = new SimpleCommand("KhachHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RKhachHangView(), "Khach Hang", ReferenceDataManager<RKhachHangDto>.Instance.Load)
            );
            _MaKhachHangFilter.ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            _MaChanhFilter = new HeaderComboBoxFilterModel(
                "Chanh", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangChanhDto.MaChanh),
                typeof(int),
                nameof(RChanhDto.TenChanh),
                nameof(RChanhDto.Ma));
            _MaChanhFilter.AddCommand = new SimpleCommand("ChanhAddCommand",
                () =>
                {
                    base.ProccessHeaderAddCommand(
                new View.RChanhView(), "Chanh", ReferenceDataManager<RChanhDto>.Instance.Load);
                },
                () => true
            );
            _MaChanhFilter.ItemSource = ReferenceDataManager<RChanhDto>.Instance.Get();
        }
    }
}
