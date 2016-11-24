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

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _MaPhuongTienFilter;
        HeaderFilterBaseModel _TenNhanVienFilter;

        public RNhanVienViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RNhanVien_ID, nameof(RNhanVienDto.ID), typeof(int));

            _MaPhuongTienFilter = new HeaderComboBoxFilterModel(
                TextManager.RNhanVien_MaPhuongTien, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RNhanVienDto.MaPhuongTien),
                typeof(int),
                nameof(RPhuongTienDto.TenHienThi),
                nameof(RPhuongTienDto.ID))
            {
                AddCommand = new SimpleCommand("MaPhuongTienAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.RPhuongTienView(), "RPhuongTien", ReferenceDataManager<RPhuongTienDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<RPhuongTienDto>.Instance.Get()
            };

            _TenNhanVienFilter = new HeaderTextFilterModel(TextManager.RNhanVien_TenNhanVien, nameof(RNhanVienDto.TenNhanVien), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
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
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
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
