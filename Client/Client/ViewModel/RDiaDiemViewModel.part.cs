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
            _nuocFilter = new HeaderComboBoxFilterModel(
                "Nuoc", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RDiaDiemDto.MaNuoc), typeof(int), nameof(RNuocDto.TenNuoc), nameof(RNuocDto.Ma));
            _nuocFilter.AddCommand = new SimpleCommand("NuocAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RNuocView(), "Nuoc", ReferenceDataManager<RNuocDto>.Instance.Load)
            );
            _nuocFilter.ItemSource = ReferenceDataManager<RNuocDto>.Instance.Get();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RDiaDiemDto.Ma), typeof(int)));
            AddHeaderFilter(_nuocFilter);
            AddHeaderFilter(new HeaderTextFilterModel("Tinh", nameof(RDiaDiemDto.Tinh), typeof(string)));
        }
    }
}
