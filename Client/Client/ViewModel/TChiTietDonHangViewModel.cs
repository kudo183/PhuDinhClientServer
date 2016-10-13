using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public class TChiTietDonHangViewModel : BaseViewModel<TChiTietDonHangDto>
    {
        private HeaderTextFilterModel _donHangFilter;
        private HeaderComboBoxFilterModel _matHangFilter;
        
        public TChiTietDonHangViewModel() : base()
        {
            _matHangFilter = new HeaderComboBoxFilterModel(
                "Mat Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TChiTietDonHangDto.MaDonHang), typeof(int), nameof(TMatHangDto.TenMatHang), nameof(TMatHangDto.Ma));
            _matHangFilter.AddCommand = new SimpleCommand("MatHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.TMatHangView(), "Mat Hang", ReferenceDataManager<TMatHangDto>.Instance.Load)
            );
            _matHangFilter.ItemSource = ReferenceDataManager<TDonHangDto>.Instance.Get();

            HeaderFilters.Add(new HeaderTextFilterModel("Ma", nameof(TChiTietDonHangDto.Ma), typeof(int)));
            _donHangFilter = new HeaderTextFilterModel("Ma Don Hang", nameof(TChiTietDonHangDto.MaDonHang), typeof(int));
            HeaderFilters.Add(_donHangFilter);
            HeaderFilters.Add(_matHangFilter);
            HeaderFilters.Add(new HeaderTextFilterModel("So Luong", nameof(TChiTietDonHangDto.SoLuong), typeof(int)));
            HeaderFilters.Add(new HeaderTextFilterModel("Xong", nameof(TChiTietDonHangDto.Xong), typeof(bool)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }

        protected override void LoadedData(PagingResultDto<TChiTietDonHangDto> data)
        {
            ReferenceDataManager<TMatHangDto>.Instance.Load();
        }

        protected override void ProcessDtoBeforeAddToEntities(TChiTietDonHangDto dto)
        {
            dto.MatHangs = ReferenceDataManager<TMatHangDto>.Instance.Get();
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

            dto.MatHangs = ReferenceDataManager<TMatHangDto>.Instance.Get();
        }
    }
}
