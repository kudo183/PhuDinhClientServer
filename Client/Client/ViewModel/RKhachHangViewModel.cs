using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public class RKhachHangViewModel : BaseViewModel<RKhachHangDto>
    {
        private HeaderComboBoxFilterModel _diaDiemFilter;

        public RKhachHangViewModel() : base()
        {
            _diaDiemFilter = new HeaderComboBoxFilterModel(
                "Dia Diem", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangDto.MaDiaDiem),
                typeof(int), nameof(RDiaDiemDto.Tinh), nameof(RDiaDiemDto.Ma));
            _diaDiemFilter.AddCommand = new SimpleCommand("DiaDiemAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RDiaDiemView(), "Dia Diem", ReferenceDataManager<RDiaDiemDto>.Instance.Load)
            );
            _diaDiemFilter.ItemSource = ReferenceDataManager<RDiaDiemDto>.Instance.Get();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RKhachHangDto.Ma), typeof(int)));
            AddHeaderFilter(_diaDiemFilter);
            AddHeaderFilter(new HeaderTextFilterModel("Ten Khach Hang", nameof(RKhachHangDto.TenKhachHang), typeof(string)));
            AddHeaderFilter(new HeaderCheckFilterModel("Khach Rieng", nameof(RKhachHangDto.KhachRieng), typeof(bool)));
        }

        protected override void LoadedData(PagingResultDto<RKhachHangDto> data)
        {
            ReferenceDataManager<RDiaDiemDto>.Instance.Load();
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhachHangDto dto)
        {
            dto.DiaDiems = ReferenceDataManager<RDiaDiemDto>.Instance.Get();
        }

        protected override void ProcessNewAddedDto(RKhachHangDto dto)
        {
            if (_diaDiemFilter.FilterValue != null)
            {
                dto.MaDiaDiem = (int)_diaDiemFilter.FilterValue;
            }
            dto.DiaDiems = ReferenceDataManager<RDiaDiemDto>.Instance.Get();
        }
    }
}
