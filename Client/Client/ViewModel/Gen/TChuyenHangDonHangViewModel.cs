using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChuyenHangDonHangViewModel : BaseViewModel<TChuyenHangDonHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChuyenHangDonHangDto dto);
        partial void ProcessNewAddedDtoPartial(TChuyenHangDonHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaChuyenHangFilter;
        HeaderFilterBaseModel _MaDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongTheoDonHangFilter;
        HeaderFilterBaseModel _TongSoLuongThucTeFilter;

        public TChuyenHangDonHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChuyenHangDonHang_Ma, nameof(TChuyenHangDonHangDto.Ma), typeof(int));

            _MaChuyenHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChuyenHangDonHang_MaChuyenHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChuyenHangDonHangDto.MaChuyenHang),
                typeof(int),
                nameof(TChuyenHangDto.TenHienThi),
                nameof(TChuyenHangDto.Ma))
            {
                AddCommand = new SimpleCommand("MaChuyenHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TChuyenHangView(), "TChuyenHang", ReferenceDataManager<TChuyenHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TChuyenHangDto>.Instance.Get()
            };

            _MaDonHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChuyenHangDonHang_MaDonHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChuyenHangDonHangDto.MaDonHang),
                typeof(int),
                nameof(TDonHangDto.TenHienThi),
                nameof(TDonHangDto.Ma))
            {
                AddCommand = new SimpleCommand("MaDonHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TDonHangView(), "TDonHang", ReferenceDataManager<TDonHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TDonHangDto>.Instance.Get()
            };

            _TongSoLuongTheoDonHangFilter = new HeaderTextFilterModel(TextManager.TChuyenHangDonHang_TongSoLuongTheoDonHang, nameof(TChuyenHangDonHangDto.TongSoLuongTheoDonHang), typeof(int));

            _TongSoLuongThucTeFilter = new HeaderTextFilterModel(TextManager.TChuyenHangDonHang_TongSoLuongThucTe, nameof(TChuyenHangDonHangDto.TongSoLuongThucTe), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaChuyenHangFilter);
            AddHeaderFilter(_MaDonHangFilter);
            AddHeaderFilter(_TongSoLuongTheoDonHangFilter);
            AddHeaderFilter(_TongSoLuongThucTeFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TChuyenHangDto>.Instance.Load();
            ReferenceDataManager<TDonHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChuyenHangDonHangDto dto)
        {
            dto.MaChuyenHangSources = ReferenceDataManager<TChuyenHangDto>.Instance.Get();
            dto.MaDonHangSources = ReferenceDataManager<TDonHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChuyenHangDonHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaChuyenHangFilter.FilterValue != null)
            {
                dto.MaChuyenHang = (int)_MaChuyenHangFilter.FilterValue;
            }
            if (_MaDonHangFilter.FilterValue != null)
            {
                dto.MaDonHang = (int)_MaDonHangFilter.FilterValue;
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
