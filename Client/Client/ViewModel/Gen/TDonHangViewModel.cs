using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TDonHangViewModel : BaseViewModel<TDonHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TDonHangDto dto);
        partial void ProcessNewAddedDtoPartial(TDonHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaChanhFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _MaKhoHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _TongSoLuongFilter;
        HeaderFilterBaseModel _XongFilter;

        public TDonHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TDonHang_Ma, nameof(TDonHangDto.Ma), typeof(int));

            _MaChanhFilter = new HeaderComboBoxFilterModel(
                TextManager.TDonHang_MaChanh, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TDonHangDto.MaChanh),
                typeof(int?),
                nameof(RChanhDto.TenHienThi),
                nameof(RChanhDto.Ma))
            {
                AddCommand = new SimpleCommand("MaChanhAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RChanhView(), "RChanh", ReferenceDataManager<RChanhDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RChanhDto>.Instance.Get()
            };

            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TDonHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TDonHangDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenHienThi),
                nameof(RKhachHangDto.Ma))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhachHangView(), "RKhachHang", ReferenceDataManager<RKhachHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get()
            };

            _MaKhoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TDonHang_MaKhoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TDonHangDto.MaKhoHang),
                typeof(int),
                nameof(RKhoHangDto.TenHienThi),
                nameof(RKhoHangDto.Ma))
            {
                AddCommand = new SimpleCommand("MaKhoHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhoHangView(), "RKhoHang", ReferenceDataManager<RKhoHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhoHangDto>.Instance.Get()
            };

            _NgayFilter = new HeaderDateFilterModel(TextManager.TDonHang_Ngay, nameof(TDonHangDto.Ngay), typeof(System.DateTime));

            _TongSoLuongFilter = new HeaderTextFilterModel(TextManager.TDonHang_TongSoLuong, nameof(TDonHangDto.TongSoLuong), typeof(int));

            _XongFilter = new HeaderCheckFilterModel(TextManager.TDonHang_Xong, nameof(TDonHangDto.Xong), typeof(bool));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaChanhFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_MaKhoHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_TongSoLuongFilter);
            AddHeaderFilter(_XongFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RChanhDto>.Instance.Load();
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TDonHangDto dto)
        {
            dto.MaChanhSources = ReferenceDataManager<RChanhDto>.Instance.Get();
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.MaKhoHangSources = ReferenceDataManager<RKhoHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TDonHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaChanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int?)_MaChanhFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_MaKhoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_MaKhoHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_TongSoLuongFilter.FilterValue != null)
            {
                dto.TongSoLuong = (int)_TongSoLuongFilter.FilterValue;
            }
            if (_XongFilter.FilterValue != null)
            {
                dto.Xong = (bool)_XongFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
