using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChuyenKhoViewModel : BaseViewModel<TChuyenKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChuyenKhoDto dto);
        partial void ProcessNewAddedDtoPartial(TChuyenKhoDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaKhoHangNhapFilter;
        HeaderComboBoxFilterModel _MaKhoHangXuatFilter;
        HeaderComboBoxFilterModel _MaNhanVienFilter;
        HeaderDateFilterModel _NgayFilter;

        public TChuyenKhoViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChuyenKho_Ma, nameof(TChuyenKhoDto.Ma), typeof(int));
            _NgayFilter = new HeaderDateFilterModel(TextManager.TChuyenKho_Ngay, nameof(TChuyenKhoDto.Ngay), typeof(System.DateTime));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhoHangNhapFilter);
            AddHeaderFilter(_MaKhoHangXuatFilter);
            AddHeaderFilter(_MaNhanVienFilter);
            AddHeaderFilter(_NgayFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RNhanVienDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChuyenKhoDto dto)
        {
            dto.MaKhoHangNhapSources = ReferenceDataManager<RKhoHangDto>.Instance.Get();
            dto.MaKhoHangXuatSources = ReferenceDataManager<RKhoHangDto>.Instance.Get();
            dto.MaNhanVienSources = ReferenceDataManager<RNhanVienDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChuyenKhoDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaKhoHangNhapFilter.FilterValue != null)
            {
                dto.MaKhoHangNhap = (int)_MaKhoHangNhapFilter.FilterValue;
            }
            if (_MaKhoHangXuatFilter.FilterValue != null)
            {
                dto.MaKhoHangXuat = (int)_MaKhoHangXuatFilter.FilterValue;
            }
            if (_MaNhanVienFilter.FilterValue != null)
            {
                dto.MaNhanVien = (int)_MaNhanVienFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
