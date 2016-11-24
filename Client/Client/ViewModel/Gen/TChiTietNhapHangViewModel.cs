using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietNhapHangViewModel : BaseViewModel<TChiTietNhapHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietNhapHangDto dto);
        partial void ProcessNewAddedDtoPartial(TChiTietNhapHangDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _MaNhapHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;

        public TChiTietNhapHangViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.TChiTietNhapHang_ID, nameof(TChiTietNhapHangDto.ID), typeof(int));

            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiTietNhapHang_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietNhapHangDto.MaMatHang),
                typeof(int),
                nameof(TMatHangDto.TenHienThi),
                nameof(TMatHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TMatHangView(), "TMatHang", ReferenceDataManager<TMatHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TMatHangDto>.Instance.Get()
            };

            _MaNhapHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiTietNhapHang_MaNhapHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietNhapHangDto.MaNhapHang),
                typeof(int),
                nameof(TNhapHangDto.TenHienThi),
                nameof(TNhapHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaNhapHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TNhapHangView(), "TNhapHang", ReferenceDataManager<TNhapHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TNhapHangDto>.Instance.Get()
            };

            _SoLuongFilter = new HeaderTextFilterModel(TextManager.TChiTietNhapHang_SoLuong, nameof(TChiTietNhapHangDto.SoLuong), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_MaNhapHangFilter);
            AddHeaderFilter(_SoLuongFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TMatHangDto>.Instance.Load();
            ReferenceDataManager<TNhapHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietNhapHangDto dto)
        {
            dto.MaMatHangSources = ReferenceDataManager<TMatHangDto>.Instance.Get();
            dto.MaNhapHangSources = ReferenceDataManager<TNhapHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiTietNhapHangDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
            }
            if (_MaNhapHangFilter.FilterValue != null)
            {
                dto.MaNhapHang = (int)_MaNhapHangFilter.FilterValue;
            }
            if (_SoLuongFilter.FilterValue != null)
            {
                dto.SoLuong = (int)_SoLuongFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
