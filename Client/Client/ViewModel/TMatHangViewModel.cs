using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public class TMatHangViewModel : BaseViewModel<TMatHangDto>
    {
        private HeaderComboBoxFilterModel _loaiHangFilter;

        public TMatHangViewModel() : base()
        {
            _loaiHangFilter = new HeaderComboBoxFilterModel(
                "Loai Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TMatHangDto.MaLoai), typeof(int), nameof(RLoaiHangDto.TenLoai), nameof(RLoaiHangDto.Ma));
            _loaiHangFilter.AddCommand = new SimpleCommand("LoaiHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RLoaiHangView(), "Loai Hang", ReferenceDataManager<RLoaiHangDto>.Instance.Load)
            );
            _loaiHangFilter.ItemSource = ReferenceDataManager<RLoaiHangDto>.Instance.Get();

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
        }

        protected override void ProcessDtoBeforeAddToEntities(TMatHangDto dto)
        {
            dto.LoaiHangs = ReferenceDataManager<RLoaiHangDto>.Instance.Get();
        }

        protected override void ProcessNewAddedDto(TMatHangDto dto)
        {
            if (_loaiHangFilter.FilterValue != null)
            {
                dto.MaLoai = (int)_loaiHangFilter.FilterValue;
            }
            dto.LoaiHangs = ReferenceDataManager<RLoaiHangDto>.Instance.Get();
        }
    }
}
