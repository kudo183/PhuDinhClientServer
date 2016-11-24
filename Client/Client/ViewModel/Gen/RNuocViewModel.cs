using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RNuocViewModel : BaseViewModel<RNuocDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RNuocDto dto);
        partial void ProcessNewAddedDtoPartial(RNuocDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenNuocFilter;

        public RNuocViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RNuoc_ID, nameof(RNuocDto.ID), typeof(int));

            _TenNuocFilter = new HeaderTextFilterModel(TextManager.RNuoc_TenNuoc, nameof(RNuocDto.TenNuoc), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenNuocFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RNuocDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RNuocDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenNuocFilter.FilterValue != null)
            {
                dto.TenNuoc = (string)_TenNuocFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
