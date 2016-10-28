using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class GroupViewModel : BaseViewModel<GroupDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(GroupDto dto);
        partial void ProcessNewAddedDtoPartial(GroupDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderDateFilterModel _NgayTaoFilter;
        HeaderTextFilterModel _TenGroupFilter;

        public GroupViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.Group_Ma, nameof(GroupDto.Ma), typeof(int));
            _NgayTaoFilter = new HeaderDateFilterModel(TextManager.Group_NgayTao, nameof(GroupDto.NgayTao), typeof(System.DateTime));
            _TenGroupFilter = new HeaderTextFilterModel(TextManager.Group_TenGroup, nameof(GroupDto.TenGroup), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_NgayTaoFilter);
            AddHeaderFilter(_TenGroupFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(GroupDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(GroupDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_NgayTaoFilter.FilterValue != null)
            {
                dto.NgayTao = (System.DateTime)_NgayTaoFilter.FilterValue;
            }
            if (_TenGroupFilter.FilterValue != null)
            {
                dto.TenGroup = (string)_TenGroupFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
