using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChuyenKhoViewModel : BaseViewModel<TChuyenKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChuyenKhoDto dto);
        partial void ProcessNewAddedDtoPartial(TChuyenKhoDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaKhoHangNhapFilter;
        HeaderFilterBaseModel _MaKhoHangXuatFilter;
        HeaderFilterBaseModel _MaNhanVienFilter;
        HeaderFilterBaseModel _NgayFilter;

        public TChuyenKhoViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChuyenKho_Ma, nameof(TChuyenKhoDto.Ma), typeof(int));

            _MaKhoHangNhapFilter = new HeaderComboBoxFilterModel(
                TextManager.TChuyenKho_MaKhoHangNhap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChuyenKhoDto.MaKhoHangNhap),
                typeof(int),
                nameof(RKhoHangDto.TenHienThi),
                nameof(RKhoHangDto.Ma))
            {
                AddCommand = new SimpleCommand("MaKhoHangNhapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhoHangView(), "RKhoHang", ReferenceDataManager<RKhoHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhoHangDto>.Instance.Get()
            };

            _MaKhoHangXuatFilter = new HeaderComboBoxFilterModel(
                TextManager.TChuyenKho_MaKhoHangXuat, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChuyenKhoDto.MaKhoHangXuat),
                typeof(int),
                nameof(RKhoHangDto.TenHienThi),
                nameof(RKhoHangDto.Ma))
            {
                AddCommand = new SimpleCommand("MaKhoHangXuatAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhoHangView(), "RKhoHang", ReferenceDataManager<RKhoHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhoHangDto>.Instance.Get()
            };

            _MaNhanVienFilter = new HeaderComboBoxFilterModel(
                TextManager.TChuyenKho_MaNhanVien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChuyenKhoDto.MaNhanVien),
                typeof(int),
                nameof(RNhanVienDto.TenHienThi),
                nameof(RNhanVienDto.Ma))
            {
                AddCommand = new SimpleCommand("MaNhanVienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNhanVienView(), "RNhanVien", ReferenceDataManager<RNhanVienDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNhanVienDto>.Instance.Get()
            };

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
