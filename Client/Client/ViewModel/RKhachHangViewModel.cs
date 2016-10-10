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
                "MaDiaDiem", typeof(int), "Tinh", "Ma");
            _diaDiemFilter.AddCommand = new SimpleCommand("DiaDiemAddCommand",
                () => { base.ProccessHeaderAddCommand(new View.RDiaDiemView(), "Dia Diem"); },
                () => true
            );
            _diaDiemFilter.ItemSource = ReferenceDataManager<RDiaDiemDto>.Instance.Get();

            HeaderFilters.Add(new HeaderTextFilterModel("Ma", "Ma", typeof(int)));
            HeaderFilters.Add(_diaDiemFilter);
            HeaderFilters.Add(new HeaderTextFilterModel("Ten Khach Hang", "TenKhachHang", typeof(string)));
            HeaderFilters.Add(new HeaderCheckFilterModel("Khach Rieng", "KhachRieng", typeof(bool)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }

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
