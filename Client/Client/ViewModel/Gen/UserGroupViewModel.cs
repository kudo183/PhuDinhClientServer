using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class UserGroupViewModel : BaseViewModel<UserGroupDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(UserGroupDto dto);
        partial void ProcessNewAddedDtoPartial(UserGroupDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderCheckFilterModel _LaChuGroupFilter;
        HeaderComboBoxFilterModel _MaGroupFilter;
        HeaderComboBoxFilterModel _MaUserFilter;

        public UserGroupViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.UserGroup_Ma, nameof(UserGroupDto.Ma), typeof(int));
            _LaChuGroupFilter = new HeaderCheckFilterModel(TextManager.UserGroup_LaChuGroup, nameof(UserGroupDto.LaChuGroup), typeof(bool));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_LaChuGroupFilter);
            AddHeaderFilter(_MaGroupFilter);
            AddHeaderFilter(_MaUserFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<GroupDto>.Instance.Load();
            ReferenceDataManager<UserDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(UserGroupDto dto)
        {
            dto.MaGroupSources = ReferenceDataManager<GroupDto>.Instance.Get();
            dto.MaUserSources = ReferenceDataManager<UserDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(UserGroupDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_LaChuGroupFilter.FilterValue != null)
            {
                dto.LaChuGroup = (bool)_LaChuGroupFilter.FilterValue;
            }
            if (_MaGroupFilter.FilterValue != null)
            {
                dto.MaGroup = (int)_MaGroupFilter.FilterValue;
            }
            if (_MaUserFilter.FilterValue != null)
            {
                dto.MaUser = (int)_MaUserFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
