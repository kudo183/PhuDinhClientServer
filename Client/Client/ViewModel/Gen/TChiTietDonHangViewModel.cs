using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietDonHangViewModel : BaseViewModel<TChiTietDonHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietDonHangDto dto);
        partial void ProcessNewAddedDtoPartial(TChiTietDonHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderComboBoxFilterModel _MaDonHangFilter;
        HeaderComboBoxFilterModel _MaMatHangFilter;
        HeaderTextFilterModel _SoLuongFilter;
        HeaderCheckFilterModel _XongFilter;

        public TChiTietDonHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChiTietDonHang_Ma, nameof(TChiTietDonHangDto.Ma), typeof(int));

            _MaDonHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiTietDonHang_MaDonHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietDonHangDto.MaDonHang),
                typeof(int),
                nameof(TDonHangDto.TenHienThi),
                nameof(TDonHangDto.Ma));
            _MaDonHangFilter.AddCommand = new SimpleCommand("MaDonHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.TDonHangView(), "TDonHang", ReferenceDataManager<TDonHangDto>.Instance.Load)
            );
            _MaDonHangFilter.ItemSource = ReferenceDataManager<TDonHangDto>.Instance.Get();

            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiTietDonHang_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietDonHangDto.MaMatHang),
                typeof(int),
                nameof(TMatHangDto.TenHienThi),
                nameof(TMatHangDto.Ma));
            _MaMatHangFilter.AddCommand = new SimpleCommand("MaMatHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.TMatHangView(), "TMatHang", ReferenceDataManager<TMatHangDto>.Instance.Load)
            );
            _MaMatHangFilter.ItemSource = ReferenceDataManager<TMatHangDto>.Instance.Get();

            _SoLuongFilter = new HeaderTextFilterModel(TextManager.TChiTietDonHang_SoLuong, nameof(TChiTietDonHangDto.SoLuong), typeof(int));

            _XongFilter = new HeaderCheckFilterModel(TextManager.TChiTietDonHang_Xong, nameof(TChiTietDonHangDto.Xong), typeof(bool));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaDonHangFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_SoLuongFilter);
            AddHeaderFilter(_XongFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TDonHangDto>.Instance.Load();
            ReferenceDataManager<TMatHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietDonHangDto dto)
        {
            dto.MaDonHangSources = ReferenceDataManager<TDonHangDto>.Instance.Get();
            dto.MaMatHangSources = ReferenceDataManager<TMatHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiTietDonHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaDonHangFilter.FilterValue != null)
            {
                dto.MaDonHang = (int)_MaDonHangFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
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
