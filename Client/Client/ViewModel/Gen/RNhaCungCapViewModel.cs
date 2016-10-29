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

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _TenNhaCungCapFilter;

        public RNhaCungCapViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RNhaCungCap_Ma, nameof(RNhaCungCapDto.Ma), typeof(int));

            _TenNhaCungCapFilter = new HeaderTextFilterModel(TextManager.RNhaCungCap_TenNhaCungCap, nameof(RNhaCungCapDto.TenNhaCungCap), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenNhaCungCapFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RNhaCungCapDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RNhaCungCapDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
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
