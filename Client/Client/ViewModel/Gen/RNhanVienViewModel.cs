using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RNhanVienViewModel : BaseViewModel<RNhanVienDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RNhanVienDto dto);
        partial void ProcessNewAddedDtoPartial(RNhanVienDto dto);

        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaPhuongTienFilter;
        HeaderFilterBaseModel _TenNhanVienFilter;

        public RNhanVienViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RNhanVien_Ma, nameof(RNhanVienDto.Ma), typeof(int));

            _MaPhuongTienFilter = new HeaderComboBoxFilterModel(
                TextManager.RNhanVien_MaPhuongTien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RNhanVienDto.MaPhuongTien),
                typeof(int),
                nameof(RPhuongTienDto.TenHienThi),
                nameof(RPhuongTienDto.Ma))
            {
                AddCommand = new SimpleCommand("MaPhuongTienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RPhuongTienView(), "RPhuongTien", ReferenceDataManager<RPhuongTienDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RPhuongTienDto>.Instance.Get()
            };

            _TenNhanVienFilter = new HeaderTextFilterModel(TextManager.RNhanVien_TenNhanVien, nameof(RNhanVienDto.TenNhanVien), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_MaPhuongTienFilter);
            AddHeaderFilter(_TenNhanVienFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<RPhuongTienDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(RNhanVienDto dto)
        {
            dto.MaPhuongTienSources = ReferenceDataManager<RPhuongTienDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RNhanVienDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_MaPhuongTienFilter.FilterValue != null)
            {
                dto.MaPhuongTien = (int)_MaPhuongTienFilter.FilterValue;
            }
            if (_TenNhanVienFilter.FilterValue != null)
            {
                dto.TenNhanVien = (string)_TenNhanVienFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
