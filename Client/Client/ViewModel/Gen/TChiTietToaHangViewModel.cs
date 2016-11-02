using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietToaHangViewModel : BaseViewModel<TChiTietToaHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietToaHangDto dto);
        partial void ProcessNewAddedDtoPartial(TChiTietToaHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _GiaTienFilter;
        HeaderFilterBaseModel _MaChiTietDonHangFilter;
        HeaderFilterBaseModel _MaToaHangFilter;

        public TChiTietToaHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TChiTietToaHang_Ma, nameof(TChiTietToaHangDto.Ma), typeof(int));

            _GiaTienFilter = new HeaderTextFilterModel(TextManager.TChiTietToaHang_GiaTien, nameof(TChiTietToaHangDto.GiaTien), typeof(int));

            _MaChiTietDonHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiTietToaHang_MaChiTietDonHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietToaHangDto.MaChiTietDonHang),
                typeof(int),
                nameof(TChiTietDonHangDto.TenHienThi),
                nameof(TChiTietDonHangDto.Ma))
            {
                AddCommand = new SimpleCommand("MaChiTietDonHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TChiTietDonHangView(), "TChiTietDonHang", ReferenceDataManager<TChiTietDonHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TChiTietDonHangDto>.Instance.Get()
            };

            _MaToaHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TChiTietToaHang_MaToaHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietToaHangDto.MaToaHang),
                typeof(int),
                nameof(TToaHangDto.TenHienThi),
                nameof(TToaHangDto.Ma))
            {
                AddCommand = new SimpleCommand("MaToaHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.TToaHangView(), "TToaHang", ReferenceDataManager<TToaHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<TToaHangDto>.Instance.Get()
            };

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_GiaTienFilter);
            AddHeaderFilter(_MaChiTietDonHangFilter);
            AddHeaderFilter(_MaToaHangFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TChiTietDonHangDto>.Instance.Load();
            ReferenceDataManager<TToaHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietToaHangDto dto)
        {
            dto.MaChiTietDonHangSources = ReferenceDataManager<TChiTietDonHangDto>.Instance.Get();
            dto.MaToaHangSources = ReferenceDataManager<TToaHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiTietToaHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_GiaTienFilter.FilterValue != null)
            {
                dto.GiaTien = (int)_GiaTienFilter.FilterValue;
            }
            if (_MaChiTietDonHangFilter.FilterValue != null)
            {
                dto.MaChiTietDonHang = (int)_MaChiTietDonHangFilter.FilterValue;
            }
            if (_MaToaHangFilter.FilterValue != null)
            {
                dto.MaToaHang = (int)_MaToaHangFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
