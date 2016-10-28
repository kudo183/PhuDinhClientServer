using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RKhachHangViewModel : BaseViewModel<RKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(RKhachHangDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderCheckFilterModel _KhachRiengFilter;
        HeaderComboBoxFilterModel _MaDiaDiemFilter;
        HeaderTextFilterModel _TenKhachHangFilter;

        public RKhachHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RKhachHang_Ma, nameof(RKhachHangDto.Ma), typeof(int));
            _KhachRiengFilter = new HeaderCheckFilterModel(TextManager.RKhachHang_KhachRieng, nameof(RKhachHangDto.KhachRieng), typeof(bool));
            _TenKhachHangFilter = new HeaderTextFilterModel(TextManager.RKhachHang_TenKhachHang, nameof(RKhachHangDto.TenKhachHang), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_KhachRiengFilter);
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
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_KhachRiengFilter.FilterValue != null)
            {
                dto.KhachRieng = (bool)_KhachRiengFilter.FilterValue;
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
