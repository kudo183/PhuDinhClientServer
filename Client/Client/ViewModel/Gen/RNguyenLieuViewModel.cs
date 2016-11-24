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
        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaLoaiNguyenLieuFilter;

        public RNguyenLieuViewModel() : base()
        {
            _DuongKinhFilter = new HeaderTextFilterModel(TextManager.RNguyenLieu_DuongKinh, nameof(RNguyenLieuDto.DuongKinh), typeof(int));

            _IDFilter = new HeaderTextFilterModel(TextManager.RNguyenLieu_ID, nameof(RNguyenLieuDto.ID), typeof(int));

            _MaLoaiNguyenLieuFilter = new HeaderComboBoxFilterModel(
                TextManager.RNguyenLieu_MaLoaiNguyenLieu, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RNguyenLieuDto.MaLoaiNguyenLieu),
                typeof(int),
                nameof(RLoaiNguyenLieuDto.TenHienThi),
                nameof(RLoaiNguyenLieuDto.ID))
            {
                AddCommand = new SimpleCommand("MaLoaiNguyenLieuAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RLoaiNguyenLieuView(), "RLoaiNguyenLieu", ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Get()
            };

            InitFilterPartial();

            AddHeaderFilter(_DuongKinhFilter);
            AddHeaderFilter(_IDFilter);
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
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
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
