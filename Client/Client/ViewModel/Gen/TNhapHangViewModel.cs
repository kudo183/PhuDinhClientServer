using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TNhapHangViewModel : BaseViewModel<TNhapHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TNhapHangDto dto);
        partial void ProcessNewAddedDtoPartial(TNhapHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _MaNhaCungCapFilter;
        HeaderFilterBaseModel _MaNhanVienFilter;
        HeaderFilterBaseModel _NgayFilter;

        public TNhapHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TNhapHang_Ma, nameof(TNhapHangDto.Ma), typeof(int));

            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TNhapHang_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TNhapHangDto.MaKhoHang),
                typeof(int),
                nameof(RKhoHangDto.TenHienThi),
                nameof(RKhoHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhoHangView(), "RKhoHang", ReferenceDataManager<RKhoHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhoHangDto>.Instance.Get()
            };

            _MaNhaCungCapFilter = new HeaderComboBoxFilterModel(
                TextManager.TNhapHang_MaNhaCungCap, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TNhapHangDto.MaNhaCungCap),
                typeof(int),
                nameof(RNhaCungCapDto.TenHienThi),
                nameof(RNhaCungCapDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhaCungCapAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNhaCungCapView(), "RNhaCungCap", ReferenceDataManager<RNhaCungCapDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNhaCungCapDto>.Instance.Get()
            };

            _MaNhanVienFilter = new HeaderComboBoxFilterModel(
                TextManager.TNhapHang_MaNhanVien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TNhapHangDto.MaNhanVien),
                typeof(int),
                nameof(RNhanVienDto.TenHienThi),
                nameof(RNhanVienDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhanVienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RNhanVienView(), "RNhanVien", ReferenceDataManager<RNhanVienDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RNhanVienDto>.Instance.Get()
            };

            _NgayFilter = new HeaderDateFilterModel(TextManager.TNhapHang_Ngay, nameof(TNhapHangDto.Ngay), typeof(System.DateTime));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_MaNhaCungCapFilter);
            AddHeaderFilter(_MaNhanVienFilter);
            AddHeaderFilter(_NgayFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RNhaCungCapDto>.Instance.Load();
            ReferenceDataManager<RNhanVienDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TNhapHangDto dto)
        {
            dto.MaKhoHangSources = ReferenceDataManager<RKhoHangDto>.Instance.Get();
            dto.MaNhaCungCapSources = ReferenceDataManager<RNhaCungCapDto>.Instance.Get();
            dto.MaNhanVienSources = ReferenceDataManager<RNhanVienDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TNhapHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_MaNhaCungCapFilter.FilterValue != null)
            {
                dto.MaNhaCungCap = (int)_MaNhaCungCapFilter.FilterValue;
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
