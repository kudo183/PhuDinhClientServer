using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietChuyenHangDonHangViewModel : BaseViewModel<TChiTietChuyenHangDonHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietChuyenHangDonHangDto dto);
        partial void ProcessNewAddedDtoPartial(TChiTietChuyenHangDonHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaChiTietDonHangFilter;
        HeaderComboBoxFilterModel _MaChuyenHangDonHangFilter;
        HeaderTextFilterModel _SoLuongFilter;
        HeaderTextFilterModel _SoLuongTheoDonHangFilter;

        public TChiTietChuyenHangDonHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenHangDonHang_Ma, nameof(TChiTietChuyenHangDonHangDto.Ma), typeof(int));
            _SoLuongFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenHangDonHang_SoLuong, nameof(TChiTietChuyenHangDonHangDto.SoLuong), typeof(int));
            _SoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenHangDonHang_SoLuongTheoDonHang, nameof(TChiTietChuyenHangDonHangDto.SoLuongTheoDonHang), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaChiTietDonHangFilter);
            AddHeaderFilter(_MaChuyenHangDonHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_SoLuongTheoDonHangFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TChiTietDonHangDto>.Instance.Load();
            ReferenceDataManager<TChuyenHangDonHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietChuyenHangDonHangDto dto)
        {
            dto.MaChiTietDonHangSources = ReferenceDataManager<TChiTietDonHangDto>.Instance.Get();
            dto.MaChuyenHangDonHangSources = ReferenceDataManager<TChuyenHangDonHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiTietChuyenHangDonHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaChiTietDonHangFilter.FilterValue != null)
            {
                dto.MaChiTietDonHang = (int)_MaChiTietDonHangFilter.FilterValue;
            }
            if (_MaChuyenHangDonHangFilter.FilterValue != null)
            {
                dto.MaChuyenHangDonHang = (int)_MaChuyenHangDonHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
            }
            if (_SoLuongTheoDonHangFilter.FilterValue != null)
            {
                dto.SoLuongTheoDonHang = (int)_SoLuongTheoDonHangFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
