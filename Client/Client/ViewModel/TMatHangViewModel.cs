using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class TMatHangViewModel : BaseViewModel<TMatHangDto>
    {
        private HeaderComboBoxFilterModel _loaiHangFilter;

        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TMatHangDto dto);

        public TMatHangViewModel() : base()
        {
            InitFilterPartial();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(TMatHangDto.Ma), typeof(int)));
            AddHeaderFilter(_loaiHangFilter);
            AddHeaderFilter(new HeaderTextFilterModel("Ten MH", nameof(TMatHangDto.TenMatHang), typeof(string)));
            AddHeaderFilter(new HeaderTextFilterModel("Ten MH Day du", nameof(TMatHangDto.TenMatHangDayDu), typeof(string)));
            AddHeaderFilter(new HeaderTextFilterModel("Ten MH In", nameof(TMatHangDto.TenMatHangIn), typeof(string)));
            AddHeaderFilter(new HeaderTextFilterModel("So Ky", nameof(TMatHangDto.SoKy), typeof(int)));
            AddHeaderFilter(new HeaderTextFilterModel("So Met", nameof(TMatHangDto.SoMet), typeof(int)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RLoaiHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TMatHangDto dto)
        {
            dto.LoaiHangs = ReferenceDataManager<RLoaiHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TMatHangDto dto)
        {
            if (_loaiHangFilter.FilterValue != null)
            {
                dto.MaLoai = (int)_loaiHangFilter.FilterValue;
            }

            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
