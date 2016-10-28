using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RDiaDiemViewModel : BaseViewModel<RDiaDiemDto>
    {
        partial void InitFilterPartial()
        {
            _MaNuocFilter = new HeaderComboBoxFilterModel(
                "Nuoc", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RDiaDiemDto.MaNuoc), typeof(int), nameof(RNuocDto.TenNuoc), nameof(RNuocDto.Ma));
            _MaNuocFilter.AddCommand = new SimpleCommand("NuocAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RNuocView(), "Nuoc", ReferenceDataManager<RNuocDto>.Instance.Load)
            );
            _MaNuocFilter.ItemSource = ReferenceDataManager<RNuocDto>.Instance.Get();
        }
    }
}
