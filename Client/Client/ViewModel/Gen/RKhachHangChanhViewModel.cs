using SimpleDataGrid.ViewModel;
using DTO;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RKhachHangChanhViewModel : BaseViewModel<RKhachHangChanhDto>
    {
        private HeaderComboBoxFilterModel _khachHangFilter;
        private HeaderComboBoxFilterModel _chanhFilter;

        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RKhachHangChanhDto dto);

        public RKhachHangChanhViewModel() : base()
        {
            InitFilterPartial();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RKhachHangChanhDto.Ma), typeof(int)));
            AddHeaderFilter(_khachHangFilter);
            AddHeaderFilter(_chanhFilter);
            AddHeaderFilter(new HeaderCheckFilterModel("La Mac Dinh", nameof(RKhachHangChanhDto.LaMacDinh), typeof(bool)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<RChanhDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhachHangChanhDto dto)
        {
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.MaChanhSources = ReferenceDataManager<RChanhDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RKhachHangChanhDto dto)
        {
            if (_khachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_khachHangFilter.FilterValue;
            }

            if (_chanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int)_chanhFilter.FilterValue;
            }

            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
