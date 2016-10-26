using SimpleDataGrid.ViewModel;
using DTO;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RDiaDiemViewModel : BaseViewModel<RDiaDiemDto>
    {
        private HeaderComboBoxFilterModel _nuocFilter;

        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RDiaDiemDto dto);

        public RDiaDiemViewModel() : base()
        {
            InitFilterPartial();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RDiaDiemDto.Ma), typeof(int)));
            AddHeaderFilter(_nuocFilter);
            AddHeaderFilter(new HeaderTextFilterModel("Tinh", nameof(RDiaDiemDto.Tinh), typeof(string)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RNuocDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RDiaDiemDto dto)
        {
            dto.Nuocs = ReferenceDataManager<RNuocDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RDiaDiemDto dto)
        {
            if (_nuocFilter.FilterValue != null)
            {
                dto.MaNuoc = (int)_nuocFilter.FilterValue;
            }

            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
