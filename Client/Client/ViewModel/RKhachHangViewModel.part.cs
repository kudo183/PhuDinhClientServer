using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RKhachHangViewModel : BaseViewModel<RKhachHangDto>
    {
        partial void InitFilterPartial()
        {
            _MaDiaDiemFilter = new HeaderComboBoxFilterModel(
                "Dia Diem", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangDto.MaDiaDiem),
                typeof(int), nameof(RDiaDiemDto.Tinh), nameof(RDiaDiemDto.Ma));
            _MaDiaDiemFilter.AddCommand = new SimpleCommand("DiaDiemAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RDiaDiemView(), "Dia Diem", ReferenceDataManager<RDiaDiemDto>.Instance.Load)
            );
            _MaDiaDiemFilter.ItemSource = ReferenceDataManager<RDiaDiemDto>.Instance.Get();
        }
    }
}
