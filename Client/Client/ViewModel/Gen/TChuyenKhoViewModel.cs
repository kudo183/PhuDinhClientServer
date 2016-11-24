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

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaKhoHangNhapFilter;
        HeaderFilterBaseModel _MaKhoHangXuatFilter;
        HeaderFilterBaseModel _MaNhanVienFilter;
        HeaderFilterBaseModel _NgayFilter;

        public TChuyenKhoViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.TChuyenKho_ID, nameof(TChuyenKhoDto.ID), typeof(int));

            _MaKhoHangNhapFilter = new HeaderComboBoxFilterModel(
                TextManager.TChuyenKho_MaKhoHangNhap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChuyenKhoDto.MaKhoHangNhap),
                typeof(int),
                nameof(RKhoHangDto.TenHienThi),
                nameof(RKhoHangDto.ID))
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
                nameof(RKhoHangDto.ID))
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
                nameof(RNhanVienDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNhanVienView(), "RNhanVien", ReferenceDataManager<RNhanVienDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNhanVienDto>.Instance.Get()
            };

            _NgayFilter = new HeaderDateFilterModel(TextManager.TChuyenKho_Ngay, nameof(TChuyenKhoDto.Ngay), typeof(System.DateTime));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
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
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
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
