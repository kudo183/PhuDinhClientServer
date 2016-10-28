using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RKhachHangChanhViewModel : BaseViewModel<RKhachHangChanhDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RKhachHangChanhDto dto);
        partial void ProcessNewAddedDtoPartial(RKhachHangChanhDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderCheckFilterModel _LaMacDinhFilter;
        HeaderComboBoxFilterModel _MaChanhFilter;
        HeaderComboBoxFilterModel _MaKhachHangFilter;

        public RKhachHangChanhViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RKhachHangChanh_Ma, nameof(RKhachHangChanhDto.Ma), typeof(int));
            _LaMacDinhFilter = new HeaderCheckFilterModel(TextManager.RKhachHangChanh_LaMacDinh, nameof(RKhachHangChanhDto.LaMacDinh), typeof(bool));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_LaMacDinhFilter);
            AddHeaderFilter(_MaChanhFilter);
            AddHeaderFilter(_MaKhachHangFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RChanhDto>.Instance.Load();
            ReferenceDataManager<RKhachHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhachHangChanhDto dto)
        {
            dto.MaChanhSources = ReferenceDataManager<RChanhDto>.Instance.Get();
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RKhachHangChanhDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_LaMacDinhFilter.FilterValue != null)
            {
                dto.LaMacDinh = (bool)_LaMacDinhFilter.FilterValue;
            }
            if (_MaChanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int)_MaChanhFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
