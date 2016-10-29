using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChuyenHangViewModel : BaseViewModel<TChuyenHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChuyenHangDto dto);
        partial void ProcessNewAddedDtoPartial(TChuyenHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _GioFilter;
        HeaderComboBoxFilterModel _MaNhanVienGiaoHangFilter;
        HeaderDateFilterModel _NgayFilter;
        HeaderTextFilterModel _TongDonHangFilter;
        HeaderTextFilterModel _TongSoLuongTheoDonHangFilter;
        HeaderTextFilterModel _TongSoLuongThucTeFilter;

        public TChuyenHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChuyenHang_Ma, nameof(TChuyenHangDto.Ma), typeof(int));

            _GioFilter = new HeaderTextFilterModel(TextManager.TChuyenHang_Gio, nameof(TChuyenHangDto.Gio), typeof(System.TimeSpan?));

            _MaNhanVienGiaoHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChuyenHang_MaNhanVienGiaoHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChuyenHangDto.MaNhanVienGiaoHang),
                typeof(int),
                nameof(RNhanVienDto.TenHienThi),
                nameof(RNhanVienDto.Ma));
            _MaNhanVienGiaoHangFilter.AddCommand = new SimpleCommand("MaNhanVienGiaoHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RNhanVienView(), "RNhanVien", ReferenceDataManager<RNhanVienDto>.Instance.Load)
            );
            _MaNhanVienGiaoHangFilter.ItemSource = ReferenceDataManager<RNhanVienDto>.Instance.Get();

            _NgayFilter = new HeaderDateFilterModel(TextManager.TChuyenHang_Ngay, nameof(TChuyenHangDto.Ngay), typeof(System.DateTime));

            _TongDonHangFilter = new HeaderTextFilterModel(TextManager.TChuyenHang_TongDonHang, nameof(TChuyenHangDto.TongDonHang), typeof(int));

            _TongSoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.TChuyenHang_TongSoLuongTheoDonHang, nameof(TChuyenHangDto.TongSoLuongTheoDonHang), typeof(int));

            _TongSoLuongThucTeFilter = new HeaderTextFilterModel(TextManager.TChuyenHang_TongSoLuongThucTe, nameof(TChuyenHangDto.TongSoLuongThucTe), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_GioFilter);
            AddHeaderFilter(_MaNhanVienGiaoHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_TongDonHangFilter);
            AddHeaderFilter(_TongSoLuongTheoDonHangFilter);
            AddHeaderFilter(_TongSoLuongThucTeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RNhanVienDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChuyenHangDto dto)
        {
            dto.MaNhanVienGiaoHangSources = ReferenceDataManager<RNhanVienDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChuyenHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_GioFilter.FilterValue != null)
            {
                dto.Gio = (System.TimeSpan?)_GioFilter.FilterValue;
            }
            if (_MaNhanVienGiaoHangFilter.FilterValue != null)
            {
                dto.MaNhanVienGiaoHang = (int)_MaNhanVienGiaoHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }
            if (_TongDonHangFilter.FilterValue != null)
            {
                dto.TongDonHang = (int)_TongDonHangFilter.FilterValue;
            }
            if (_TongSoLuongTheoDonHangFilter.FilterValue != null)
            {
                dto.TongSoLuongTheoDonHang = (int)_TongSoLuongTheoDonHangFilter.FilterValue;
            }
            if (_TongSoLuongThucTeFilter.FilterValue != null)
            {
                dto.TongSoLuongThucTe = (int)_TongSoLuongThucTeFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
