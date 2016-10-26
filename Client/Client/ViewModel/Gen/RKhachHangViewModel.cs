using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RKhachHangViewModel : BaseViewModel<RKhachHangDto>
    {
        private HeaderComboBoxFilterModel _diaDiemFilter;

        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RKhachHangDto dto);

        public RKhachHangViewModel() : base()
        {
            InitFilterPartial();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RKhachHangDto.Ma), typeof(int)));
            AddHeaderFilter(_diaDiemFilter);
            AddHeaderFilter(new HeaderTextFilterModel("Ten Khach Hang", nameof(RKhachHangDto.TenKhachHang), typeof(string)));
            AddHeaderFilter(new HeaderCheckFilterModel("Khach Rieng", nameof(RKhachHangDto.KhachRieng), typeof(bool)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RDiaDiemDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhachHangDto dto)
        {
            dto.DiaDiems = ReferenceDataManager<RDiaDiemDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RKhachHangDto dto)
        {
            if (_diaDiemFilter.FilterValue != null)
            {
                dto.MaDiaDiem = (int)_diaDiemFilter.FilterValue;
            }

            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
