using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RKhachHangViewModel : BaseViewModel<RKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(RKhachHangDto dto);

        HeaderFilterBaseModel _KhachRiengFilter;
        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaDiaDiemFilter;
        HeaderFilterBaseModel _TenKhachHangFilter;

        public RKhachHangViewModel() : base()
        {
            _KhachRiengFilter = new HeaderCheckFilterModel(TextManager.RKhachHang_KhachRieng, nameof(RKhachHangDto.KhachRieng), typeof(bool));

            _MaFilter = new HeaderTextFilterModel(TextManager.RKhachHang_Ma, nameof(RKhachHangDto.Ma), typeof(int));

            _MaDiaDiemFilter = new HeaderComboBoxFilterModel(
                TextManager.RKhachHang_MaDiaDiem, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangDto.MaDiaDiem),
                typeof(int),
                nameof(RDiaDiemDto.TenHienThi),
                nameof(RDiaDiemDto.Ma))
            {
                AddCommand = new SimpleCommand("MaDiaDiemAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RDiaDiemView(), "RDiaDiem", ReferenceDataManager<RDiaDiemDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RDiaDiemDto>.Instance.Get()
            };

            _TenKhachHangFilter = new HeaderTextFilterModel(TextManager.RKhachHang_TenKhachHang, nameof(RKhachHangDto.TenKhachHang), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_KhachRiengFilter);
            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaDiaDiemFilter);
            AddHeaderFilter(_TenKhachHangFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RDiaDiemDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhachHangDto dto)
        {
            dto.MaDiaDiemSources = ReferenceDataManager<RDiaDiemDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RKhachHangDto dto)
        {
            if (_KhachRiengFilter.FilterValue != null)
            {
                dto.KhachRieng = (bool)_KhachRiengFilter.FilterValue;
            }
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaDiaDiemFilter.FilterValue != null)
            {
                dto.MaDiaDiem = (int)_MaDiaDiemFilter.FilterValue;
            }
            if (_TenKhachHangFilter.FilterValue != null)
            {
                dto.TenKhachHang = (string)_TenKhachHangFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
