using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;
using System.Linq;

namespace Client.ViewModel
{
    public class TDonHangViewModel : BaseViewModel<TDonHangDto>
    {
        private HeaderComboBoxFilterModel _chanhFilter;
        private HeaderComboBoxFilterModel _khachHangFilter;
        private HeaderComboBoxFilterModel _khoHangFilter;

        public TDonHangViewModel() : base()
        {
            _khachHangFilter = new HeaderComboBoxFilterModel(
                "Khach Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                "MaKhachHang", typeof(int), "TenKhachHang", "Ma");
            _khachHangFilter.AddCommand = new SimpleCommand("KhachHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                  new View.RKhachHangView(), "Khach Hang Chanh", ReferenceDataManager<RKhachHangDto>.Instance.Load)
            );
            _khachHangFilter.ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            _khoHangFilter = new HeaderComboBoxFilterModel(
                "Kho Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                "MaKhoHang", typeof(int), "TenKhoHang", "Ma");
            _khoHangFilter.AddCommand = new SimpleCommand("KhoHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                  new View.RKhoHangView(), "Kho Hang", ReferenceDataManager<RKhoHangDto>.Instance.Load)
            );
            _khoHangFilter.ItemSource = ReferenceDataManager<RKhoHangDto>.Instance.Get();

            _chanhFilter = new HeaderComboBoxFilterModel(
                "Chanh", HeaderComboBoxFilterModel.ComboBoxFilter,
                "MaChanh", typeof(int), "TenChanh", "Ma");
            _chanhFilter.AddCommand = new SimpleCommand("ChanhAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RKhachHangChanhView(), "Khach Hang Chanh", AfterKhachHangChanhDialog)
            );
            _chanhFilter.ItemSource = ReferenceDataManager<RChanhDto>.Instance.Get();

            HeaderFilters.Add(new HeaderTextFilterModel("Ma", "Ma", typeof(int)));
            HeaderFilters.Add(new HeaderDateFilterModel("Ngay", "Ngay", typeof(System.DateTime)));
            HeaderFilters.Add(_khachHangFilter);
            HeaderFilters.Add(_khoHangFilter);
            HeaderFilters.Add(_chanhFilter);
            HeaderFilters.Add(new HeaderTextFilterModel("So Luong", "TongSoLuong", typeof(int)));
            HeaderFilters.Add(new HeaderCheckFilterModel("Xong", "Xong", typeof(bool)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }

        protected override void LoadedData(PagingResultDto<TDonHangDto> data)
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<RKhachHangChanhDto>.Instance.Load();
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RChanhDto>.Instance.Load();
        }

        protected override void ProcessDtoBeforeAddToEntities(TDonHangDto dto)
        {
            dto.KhachHangs = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.KhoHangs = ReferenceDataManager<RKhoHangDto>.Instance.Get();
            dto.KhachHangChanhs = ReferenceDataManager<RKhachHangChanhDto>.Instance.GetList()
                 .Where(p => p.MaKhachHang == dto.MaKhachHang);

            dto.MaKhachHangChangedAction = ProcessMaKhachHangChanged;
        }

        protected override void ProcessNewAddedDto(TDonHangDto dto)
        {
            dto.Ngay = System.DateTime.UtcNow;
            if (_chanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int)_chanhFilter.FilterValue;
            }
            if (_khachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_khachHangFilter.FilterValue;
            }
            if (_khoHangFilter.FilterValue != null)
            {
                dto.MaKhoHang = (int)_khoHangFilter.FilterValue;
            }
            dto.KhachHangs = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.KhoHangs = ReferenceDataManager<RKhoHangDto>.Instance.Get();

            dto.MaKhachHangChangedAction = ProcessMaKhachHangChanged;
        }

        void ProcessMaKhachHangChanged(TDonHangDto dto)
        {
            dto.KhachHangChanhs = ReferenceDataManager<RKhachHangChanhDto>.Instance.GetList()
                 .Where(p => p.MaKhachHang == dto.MaKhachHang);
        }

        void AfterKhachHangChanhDialog()
        {
            ReferenceDataManager<RChanhDto>.Instance.Load();
            ReferenceDataManager<RKhachHangChanhDto>.Instance.Load();
            foreach (var dto in Entities)
            {
                dto.KhachHangChanhs = ReferenceDataManager<RKhachHangChanhDto>.Instance.GetList()
                 .Where(p => p.MaKhachHang == dto.MaKhachHang);
            }
        }
    }
}
