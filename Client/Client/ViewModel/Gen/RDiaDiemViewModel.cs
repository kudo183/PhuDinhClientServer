using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RDiaDiemViewModel : BaseViewModel<RDiaDiemDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RDiaDiemDto dto);
        partial void ProcessNewAddedDtoPartial(RDiaDiemDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaNuocFilter;
        HeaderFilterBaseModel _TinhFilter;

        public RDiaDiemViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RDiaDiem_Ma, nameof(RDiaDiemDto.Ma), typeof(int));

            _MaNuocFilter = new HeaderComboBoxFilterModel(
                TextManager.RDiaDiem_MaNuoc, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RDiaDiemDto.MaNuoc),
                typeof(int),
                nameof(RNuocDto.TenHienThi),
                nameof(RNuocDto.ID))
            {
                AddCommand = new SimpleCommand("MaNuocAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNuocView(), "RNuoc", ReferenceDataManager<RNuocDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNuocDto>.Instance.Get()
            };

            _TinhFilter = new HeaderTextFilterModel(TextManager.RDiaDiem_Tinh, nameof(RDiaDiemDto.Tinh), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaNuocFilter);
            AddHeaderFilter(_TinhFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RNuocDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RDiaDiemDto dto)
        {
            dto.MaNuocSources = ReferenceDataManager<RNuocDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RDiaDiemDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaNuocFilter.FilterValue != null)
            {
                dto.MaNuoc = (int)_MaNuocFilter.FilterValue;
            }
            if (_TinhFilter.FilterValue != null)
            {
                dto.Tinh = (string)_TinhFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
