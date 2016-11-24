using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RNhaCungCapViewModel : BaseViewModel<RNhaCungCapDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RNhaCungCapDto dto);
        partial void ProcessNewAddedDtoPartial(RNhaCungCapDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenNhaCungCapFilter;

        public RNhaCungCapViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RNhaCungCap_ID, nameof(RNhaCungCapDto.ID), typeof(int));

            _TenNhaCungCapFilter = new HeaderTextFilterModel(TextManager.RNhaCungCap_TenNhaCungCap, nameof(RNhaCungCapDto.TenNhaCungCap), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenNhaCungCapFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RNhaCungCapDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RNhaCungCapDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenNhaCungCapFilter.FilterValue != null)
            {
                dto.TenNhaCungCap = (string)_TenNhaCungCapFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
