using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiPhiViewModel : BaseViewModel<TChiPhiDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiPhiDto dto);
        partial void ProcessNewAddedDtoPartial(TChiPhiDto dto);

        HeaderFilterBaseModel _GhiChuFilter;
        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaLoaiChiPhiFilter;
        HeaderFilterBaseModel _MaNhanVienGiaoHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoTienFilter;

        public TChiPhiViewModel() : base()
        {
            _GhiChuFilter = new HeaderTextFilterModel(TextManager.TChiPhi_GhiChu, nameof(TChiPhiDto.GhiChu), typeof(string));

            _MaFilter = new HeaderTextFilterModel(TextManager.TChiPhi_Ma, nameof(TChiPhiDto.Ma), typeof(int));

            _MaLoaiChiPhiFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiPhi_MaLoaiChiPhi, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiPhiDto.MaLoaiChiPhi),
                typeof(int),
                nameof(RLoaiChiPhiDto.TenHienThi),
                nameof(RLoaiChiPhiDto.ID))
            {
                AddCommand = new SimpleCommand("MaLoaiChiPhiAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RLoaiChiPhiView(), "RLoaiChiPhi", ReferenceDataManager<RLoaiChiPhiDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RLoaiChiPhiDto>.Instance.Get()
            };

            _MaNhanVienGiaoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiPhi_MaNhanVienGiaoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiPhiDto.MaNhanVienGiaoHang),
                typeof(int),
                nameof(RNhanVienDto.TenHienThi),
                nameof(RNhanVienDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienGiaoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNhanVienView(), "RNhanVien", ReferenceDataManager<RNhanVienDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNhanVienDto>.Instance.Get()
            };

            _NgayFilter = new HeaderDateFilterModel(TextManager.TChiPhi_Ngay, nameof(TChiPhiDto.Ngay), typeof(System.DateTime));

            _SoTienFilter = new HeaderTextFilterModel(TextManager.TChiPhi_SoTien, nameof(TChiPhiDto.SoTien), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_GhiChuFilter);
            AddHeaderFilter(_MaFilter);
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
            if (_GhiChuFilter.FilterValue != null)
            {
                dto.GhiChu = (string)_GhiChuFilter.FilterValue;
            }
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
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
