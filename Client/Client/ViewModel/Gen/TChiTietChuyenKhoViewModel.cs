using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietChuyenKhoViewModel : BaseViewModel<TChiTietChuyenKhoDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietChuyenKhoDto dto);
        partial void ProcessNewAddedDtoPartial(TChiTietChuyenKhoDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaChuyenKhoFilter;
        HeaderFilterBaseModel _MaMatHangFilter;
        HeaderFilterBaseModel _SoLuongFilter;

        public TChiTietChuyenKhoViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenKho_ID, nameof(TChiTietChuyenKhoDto.ID), typeof(int));

            _MaChuyenKhoFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiTietChuyenKho_MaChuyenKho, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietChuyenKhoDto.MaChuyenKho),
                typeof(int),
                nameof(TChuyenKhoDto.TenHienThi),
                nameof(TChuyenKhoDto.ID))
            {
                AddCommand = new SimpleCommand("MaChuyenKhoAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TChuyenKhoView(), "TChuyenKho", ReferenceDataManager<TChuyenKhoDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TChuyenKhoDto>.Instance.Get()
            };

            _MaMatHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiTietChuyenKho_MaMatHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietChuyenKhoDto.MaMatHang),
                typeof(int),
                nameof(TMatHangDto.TenHienThi),
                nameof(TMatHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaMatHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TMatHangView(), "TMatHang", ReferenceDataManager<TMatHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TMatHangDto>.Instance.Get()
            };

            _SoLuongFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenKho_SoLuong, nameof(TChiTietChuyenKhoDto.SoLuong), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_MaChuyenKhoFilter);
            AddHeaderFilter(_MaMatHangFilter);
            AddHeaderFilter(_SoLuongFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TChuyenKhoDto>.Instance.Load();
            ReferenceDataManager<TMatHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietChuyenKhoDto dto)
        {
            dto.MaChuyenKhoSources = ReferenceDataManager<TChuyenKhoDto>.Instance.Get();
            dto.MaMatHangSources = ReferenceDataManager<TMatHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiTietChuyenKhoDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_MaChuyenKhoFilter.FilterValue != null)
            {
                dto.MaChuyenKho = (int)_MaChuyenKhoFilter.FilterValue;
            }
            if (_MaMatHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_MaMatHangFilter.FilterValue;
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
