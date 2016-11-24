using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class SwaGroupViewModel : BaseViewModel<SwaGroupDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(SwaGroupDto dto);
        partial void ProcessNewAddedDtoPartial(SwaGroupDto dto);

        HeaderFilterBaseModel _CreateDateFilter;
        HeaderFilterBaseModel _GroupNameFilter;
        HeaderFilterBaseModel _IDFilter;

        public SwaGroupViewModel() : base()
        {
            _CreateDateFilter = new HeaderDateFilterModel(TextManager.SwaGroup_CreateDate, nameof(SwaGroupDto.CreateDate), typeof(System.DateTime));

            _GroupNameFilter = new HeaderTextFilterModel(TextManager.SwaGroup_GroupName, nameof(SwaGroupDto.GroupName), typeof(string));

            _IDFilter = new HeaderTextFilterModel(TextManager.SwaGroup_ID, nameof(SwaGroupDto.ID), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_CreateDateFilter);
            AddHeaderFilter(_GroupNameFilter);
            AddHeaderFilter(_IDFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(SwaGroupDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(SwaGroupDto dto)
        {
            if (_CreateDateFilter.FilterValue != null)
            {
                dto.CreateDate = (System.DateTime)_CreateDateFilter.FilterValue;
            }
            if (_GroupNameFilter.FilterValue != null)
            {
                dto.GroupName = (string)_GroupNameFilter.FilterValue;
            }
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
