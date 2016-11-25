using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RCanhBaoTonKhoViewModel : BaseViewModel<RCanhBaoTonKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RCanhBaoTonKhoDto dto);
        partial void ProcessNewAddedDtoPartial(RCanhBaoTonKhoDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _TonCaoNhatFilter;
        HeaderFilterBaseModel _TonThapNhatFilter;

        public RCanhBaoTonKhoViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RCanhBaoTonKho_Ma, nameof(RCanhBaoTonKhoDto.Ma), typeof(int));

            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.RCanhBaoTonKho_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RCanhBaoTonKhoDto.MaKhoHang),
                typeof(int),
                nameof(RKhoHangDto.TenHienThi),
                nameof(RKhoHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhoHangView(), "RKhoHang", ReferenceDataManager<RKhoHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhoHangDto>.Instance.Get()
            };

            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.RCanhBaoTonKho_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RCanhBaoTonKhoDto.MaMatHang),
                typeof(int),
                nameof(TMatHangDto.TenHienThi),
                nameof(TMatHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TMatHangView(), "TMatHang", ReferenceDataManager<TMatHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TMatHangDto>.Instance.Get()
            };

            _TonCaoNhatFilter = new HeaderTextFilterModel(TextManager.RCanhBaoTonKho_TonCaoNhat, nameof(RCanhBaoTonKhoDto.TonCaoNhat), typeof(int));

            _TonThapNhatFilter = new HeaderTextFilterModel(TextManager.RCanhBaoTonKho_TonThapNhat, nameof(RCanhBaoTonKhoDto.TonThapNhat), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_TonCaoNhatFilter);
            AddHeaderFilter(_TonThapNhatFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<TMatHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RCanhBaoTonKhoDto dto)
        {
            dto.MaKhoHangSources = ReferenceDataManager<RKhoHangDto>.Instance.Get();
            dto.MaMatHangSources = ReferenceDataManager<TMatHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RCanhBaoTonKhoDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_TonCaoNhatFilter.FilterValue != null)
            {
                dto.TonCaoNhat = (int)_TonCaoNhatFilter.FilterValue;
            }
            if (_TonThapNhatFilter.FilterValue != null)
            {
                dto.TonThapNhat = (int)_TonThapNhatFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
