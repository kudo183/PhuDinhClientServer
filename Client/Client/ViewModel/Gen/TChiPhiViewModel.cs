using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiPhiViewModel : BaseViewModel<TChiPhiDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiPhiDto dto);
        partial void ProcessNewAddedDtoPartial(TChiPhiDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _GhiChuFilter;
        HeaderComboBoxFilterModel _MaLoaiChiPhiFilter;
        HeaderComboBoxFilterModel _MaNhanVienGiaoHangFilter;
        HeaderDateFilterModel _NgayFilter;
        HeaderTextFilterModel _SoTienFilter;

        public TChiPhiViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChiPhi_Ma, nameof(TChiPhiDto.Ma), typeof(int));
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.TChiPhi_GhiChu, nameof(TChiPhiDto.GhiChu), typeof(string));
            _NgayFilter = new HeaderDateFilterModel(TextManager.TChiPhi_Ngay, nameof(TChiPhiDto.Ngay), typeof(System.DateTime));
            _SoTienFilter = new HeaderTextFilterModel(TextManager.TChiPhi_SoTien, nameof(TChiPhiDto.SoTien), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_GhiChuFilter);
            AddHeaderFilter(_MaLoaiChiPhiFilter);
            AddHeaderFilter(_MaNhanVienGiaoHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoTienFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RLoaiChiPhiDto>.Instance.Load();
            ReferenceDataManager<RNhanVienDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiPhiDto dto)
        {
            dto.MaLoaiChiPhiSources = ReferenceDataManager<RLoaiChiPhiDto>.Instance.Get();
            dto.MaNhanVienGiaoHangSources = ReferenceDataManager<RNhanVienDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiPhiDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_GhiChuFilter.FilterValue != null)
            {
                dto.GhiChu = (string)_GhiChuFilter.FilterValue;
            }
            if (_MaLoaiChiPhiFilter.FilterValue != null)
            {
                dto.MaLoaiChiPhi = (int)_MaLoaiChiPhiFilter.FilterValue;
            }
            if (_MaNhanVienGiaoHangFilter.FilterValue != null)
            {
                dto.MaNhanVienGiaoHang = (int)_MaNhanVienGiaoHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_SoTienFilter.FilterValue != null)
            {
                dto.SoTien = (int)_SoTienFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
