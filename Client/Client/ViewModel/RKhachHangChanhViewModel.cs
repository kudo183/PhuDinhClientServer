using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public class RKhachHangChanhViewModel : BaseViewModel<RKhachHangChanhDto>
    {
        private HeaderComboBoxFilterModel _khachHangFilter;
        private HeaderComboBoxFilterModel _chanhFilter;

        public RKhachHangChanhViewModel() : base()
        {
            _khachHangFilter = new HeaderComboBoxFilterModel(
                "Khach Hang", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangChanhDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenKhachHang),
                nameof(RKhachHangDto.Ma));
            _khachHangFilter.AddCommand = new SimpleCommand("KhachHangAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RKhachHangView(), "Khach Hang", ReferenceDataManager<RKhachHangDto>.Instance.Load)
            );
            _khachHangFilter.ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            _chanhFilter = new HeaderComboBoxFilterModel(
                "Chanh", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangChanhDto.MaChanh),
                typeof(int),
                nameof(RChanhDto.TenChanh),
                nameof(RChanhDto.Ma));
            _chanhFilter.AddCommand = new SimpleCommand("ChanhAddCommand",
                () =>
                {
                    base.ProccessHeaderAddCommand(
                new View.RChanhView(), "Chanh", ReferenceDataManager<RChanhDto>.Instance.Load);
                },
                () => true
            );
            _chanhFilter.ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RKhachHangChanhDto.Ma), typeof(int)));
            AddHeaderFilter(_khachHangFilter);
            AddHeaderFilter(_chanhFilter);
            AddHeaderFilter(new HeaderCheckFilterModel("La Mac Dinh", nameof(RKhachHangChanhDto.LaMacDinh), typeof(bool)));
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
            ReferenceDataManager<RChanhDto>.Instance.Load();
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhachHangChanhDto dto)
        {
            dto.KhachHangs = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.Chanhs = ReferenceDataManager<RChanhDto>.Instance.Get();
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

            dto.KhachHangs = ReferenceDataManager<RKhachHangDto>.Instance.Get();
            dto.Chanhs = ReferenceDataManager<RChanhDto>.Instance.Get();
        }
    }
}
