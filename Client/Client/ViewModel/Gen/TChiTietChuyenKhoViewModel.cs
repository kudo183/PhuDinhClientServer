using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietChuyenKhoViewModel : BaseViewModel<TChiTietChuyenKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietChuyenKhoDto dto);
        partial void ProcessNewAddedDtoPartial(TChiTietChuyenKhoDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaChuyenKhoFilter;
        HeaderComboBoxFilterModel _MaMatHangFilter;
        HeaderTextFilterModel _SoLuongFilter;

        public TChiTietChuyenKhoViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenKho_Ma, nameof(TChiTietChuyenKhoDto.Ma), typeof(int));
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenKho_SoLuong, nameof(TChiTietChuyenKhoDto.SoLuong), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaChuyenKhoFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_SoLuongFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TChuyenKhoDto>.Instance.Load();
            ReferenceDataManager<TMatHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietChuyenKhoDto dto)
        {
            dto.MaChuyenKhoSources = ReferenceDataManager<TChuyenKhoDto>.Instance.Get();
            dto.MaMatHangSources = ReferenceDataManager<TMatHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiTietChuyenKhoDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaChuyenKhoFilter.FilterValue != null)
            {
                dto.MaChuyenKho = (int)_MaChuyenKhoFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
