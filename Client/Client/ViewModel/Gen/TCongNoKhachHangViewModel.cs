using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TCongNoKhachHangViewModel : BaseViewModel<TCongNoKhachHangDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(TCongNoKhachHangDto dto);
        partial void ProcessNewAddedDtoPartial(TCongNoKhachHangDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaKhachHangFilter;
        HeaderFilterBaseModel _NgayFilter;
        HeaderFilterBaseModel _SoTienFilter;

        public TCongNoKhachHangViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.TCongNoKhachHang_Ma, nameof(TCongNoKhachHangDto.Ma), typeof(int));

            _MaKhachHangFilter = new HeaderComboBoxFilterModel(
                TextManager.TCongNoKhachHang_MaKhachHang, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(TCongNoKhachHangDto.MaKhachHang),
                typeof(int),
                nameof(RKhachHangDto.TenHienThi),
                nameof(RKhachHangDto.ID))
            {
                AddCommand = new SimpleCommand("MaKhachHangAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RKhachHangView(), "RKhachHang", ReferenceDataManager<RKhachHangDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RKhachHangDto>.Instance.Get()
            };

            _NgayFilter = new HeaderDateFilterModel(TextManager.TCongNoKhachHang_Ngay, nameof(TCongNoKhachHangDto.Ngay), typeof(System.DateTime));

            _SoTienFilter = new HeaderTextFilterModel(TextManager.TCongNoKhachHang_SoTien, nameof(TCongNoKhachHangDto.SoTien), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaKhachHangFilter);
            AddHeaderFilter(_NgayFilter);
            AddHeaderFilter(_SoTienFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RKhachHangDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(TCongNoKhachHangDto dto)
        {
            dto.MaKhachHangSources = ReferenceDataManager<RKhachHangDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(TCongNoKhachHangDto dto)
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
            if (_SoTienFilter.FilterValue != null)
            {
                dto.SoTien = (int)_SoTienFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
