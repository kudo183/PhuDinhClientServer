using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TToaHangViewModel : BaseViewModel<TToaHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TToaHangDto dto);
        partial void ProcessNewAddedDtoPartial(TToaHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _NgayFilter;

        public TToaHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TToaHang_Ma, nameof(TToaHangDto.Ma), typeof(int));

            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TToaHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TToaHangDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenHienThi),
                nameof(RKhachHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhachHangView(), "RKhachHang", ReferenceDataManager<RKhachHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get()
            };

            _NgayFilter = new HeaderDateFilterModel(TextManager.TToaHang_Ngay, nameof(TToaHangDto.Ngay), typeof(System.DateTime));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_NgayFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TToaHangDto dto)
        {
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TToaHangDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaKhachHangFilter.FilterValue != null)
            {
                dto.MaKhachHang = (int)_MaKhachHangFilter.FilterValue;
            }
            if (_NgayFilter.FilterValue != null)
            {
                dto.Ngay = (System.DateTime)_NgayFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
