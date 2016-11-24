using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RKhachHangChanhViewModel : BaseViewModel<RKhachHangChanhDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RKhachHangChanhDto dto);
        partial void ProcessNewAddedDtoPartial(RKhachHangChanhDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _LaMacDinhFilter;
        HeaderFilterBaseModel _MaChanhFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;

        public RKhachHangChanhViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RKhachHangChanh_ID, nameof(RKhachHangChanhDto.ID), typeof(int));

            _LaMacDinhFilter = new HeaderCheckFilterModel(TextManager.RKhachHangChanh_LaMacDinh, nameof(RKhachHangChanhDto.LaMacDinh), typeof(bool));

            _MaChanhFilter = new HeaderComboBoxFilterModel(
                TextManager.RKhachHangChanh_MaChanh, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangChanhDto.MaChanh),
                typeof(int),
                nameof(RChanhDto.TenHienThi),
                nameof(RChanhDto.ID))
            {
                AddCommand = new SimpleCommand("MaChanhAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RChanhView(), "RChanh", ReferenceDataManager<RChanhDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RChanhDto>.Instance.Get()
            };

            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.RKhachHangChanh_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RKhachHangChanhDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenHienThi),
                nameof(RKhachHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhachHangView(), "RKhachHang", ReferenceDataManager<RKhachHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get()
            };

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_LaMacDinhFilter);
            AddHeaderFilter(_MaChanhFilter);
            AddHeaderFilter(_MaKhachHangFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RChanhDto>.Instance.Load();
            ReferenceDataManager<RKhachHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RKhachHangChanhDto dto)
        {
            dto.MaChanhSources = ReferenceDataManager<RChanhDto>.Instance.Get();
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RKhachHangChanhDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_LaMacDinhFilter.FilterValue != null)
            {
                dto.LaMacDinh = (bool)_LaMacDinhFilter.FilterValue;
            }
            if (_MaChanhFilter.FilterValue != null)
            {
                dto.MaChanh = (int)_MaChanhFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
