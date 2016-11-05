using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RNguyenLieuViewModel : BaseViewModel<RNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(RNguyenLieuDto dto);

        HeaderFilterBaseModel _DuongKinhFilter;
        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaLoaiNguyenLieuFilter;

        public RNguyenLieuViewModel() : base()
        {
            _DuongKinhFilter = new HeaderTextFilterModel(TextManager.RNguyenLieu_DuongKinh, nameof(RNguyenLieuDto.DuongKinh), typeof(int));

            _MaFilter = new HeaderTextFilterModel(TextManager.RNguyenLieu_Ma, nameof(RNguyenLieuDto.Ma), typeof(int));

            _MaLoaiNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.RNguyenLieu_MaLoaiNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RNguyenLieuDto.MaLoaiNguyenLieu),
                typeof(int),
                nameof(RLoaiNguyenLieuDto.TenHienThi),
                nameof(RLoaiNguyenLieuDto.Ma))
            {
                AddCommand = new SimpleCommand("MaLoaiNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RLoaiNguyenLieuView(), "RLoaiNguyenLieu", ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Get()
            };

            InitFilterPartial();

            AddHeaderFilter(_DuongKinhFilter);
            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaLoaiNguyenLieuFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RNguyenLieuDto dto)
        {
            dto.MaLoaiNguyenLieuSources = ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RNguyenLieuDto dto)
        {
            if (_DuongKinhFilter.FilterValue != null)
            {
                dto.DuongKinh = (int)_DuongKinhFilter.FilterValue;
            }
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaLoaiNguyenLieuFilter.FilterValue != null)
            {
                dto.MaLoaiNguyenLieu = (int)_MaLoaiNguyenLieuFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
