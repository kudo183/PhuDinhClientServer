using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public class RDiaDiemViewModel : BaseViewModel<RDiaDiemDto>
    {
        private HeaderComboBoxFilterModel _nuocFilter;

        public RDiaDiemViewModel() : base()
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

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RNuocDto>.Instance.Load();
        }

        protected override void ProcessDtoBeforeAddToEntities(RDiaDiemDto dto)
        {
            dto.Nuocs = ReferenceDataManager<RNuocDto>.Instance.Get();
        }

        protected override void ProcessNewAddedDto(RDiaDiemDto dto)
        {
            if (_nuocFilter.FilterValue != null)
            {
                dto.MaNuoc = (int)_nuocFilter.FilterValue;
            }
            dto.Nuocs = ReferenceDataManager<RNuocDto>.Instance.Get();
        }
    }
}
