using SimpleDataGrid.ViewModel;
using DTO;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class TDonHangViewModel : BaseViewModel<TDonHangDto>
    {
        private HeaderComboBoxFilterModel _chanhFilter;
        private HeaderComboBoxFilterModel _khachHangFilter;
        private HeaderComboBoxFilterModel _khoHangFilter;

        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TDonHangDto dto);

        public TDonHangViewModel() : base()
        {
            InitFilterPartial();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(TDonHangDto.Ma), typeof(int)));
            AddHeaderFilter(new HeaderDateFilterModel("Ngay", nameof(TDonHangDto.Ngay), typeof(System.DateTime)));
            AddHeaderFilter(_khachHangFilter);
            AddHeaderFilter(_khoHangFilter);
            AddHeaderFilter(_chanhFilter);
            AddHeaderFilter(new HeaderTextFilterModel("So Luong", nameof(TDonHangDto.TongSoLuong), typeof(int)));
            AddHeaderFilter(new HeaderCheckFilterModel("Xong", nameof(TDonHangDto.Xong), typeof(bool)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RChanhDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TDonHangDto dto)
        {
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.MaKhoHangSources = ReferenceDataManager<RKhoHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TDonHangDto dto)
        {
            dto.Ngay = System.DateTime.UtcNow;
            if (_chanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int?)_chanhFilter.FilterValue;
            }
            if (_khachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_khachHangFilter.FilterValue;
            }
            if (_khoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_khoHangFilter.FilterValue;
            }

            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
