using SimpleDataGrid.ViewModel;
using DTO;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class TChiTietDonHangViewModel : BaseViewModel<TChiTietDonHangDto>
    {
        private HeaderTextFilterModel _donHangFilter;
        private HeaderComboBoxFilterModel _matHangFilter;

        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietDonHangDto dto);

        public TChiTietDonHangViewModel() : base()
        {
            InitFilterPartial();

            _donHangFilter = new HeaderTextFilterModel("Ma Don Hang", nameof(TChiTietDonHangDto.MaDonHang), typeof(int));

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(TChiTietDonHangDto.Ma), typeof(int)));
            AddHeaderFilter(_donHangFilter);
            AddHeaderFilter(_matHangFilter);
            AddHeaderFilter(new HeaderTextFilterModel("So Luong", nameof(TChiTietDonHangDto.SoLuong), typeof(int)));
            AddHeaderFilter(new HeaderTextFilterModel("Xong", nameof(TChiTietDonHangDto.Xong), typeof(bool)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<TMatHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietDonHangDto dto)
        {
            dto.MatHangs = ReferenceDataManager<TMatHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TChiTietDonHangDto dto)
        {
            if (_donHangFilter.FilterValue != null)
            {
                dto.MaDonHang = int.Parse(_donHangFilter.FilterValue.ToString());
            }

            if (_matHangFilter.FilterValue != null)
            {
                dto.MaMatHang = (int)_matHangFilter.FilterValue;
            }

            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
