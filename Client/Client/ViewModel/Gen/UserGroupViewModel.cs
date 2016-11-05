using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class UserGroupViewModel : BaseViewModel<UserGroupDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(UserGroupDto dto);
        partial void ProcessNewAddedDtoPartial(UserGroupDto dto);

        HeaderFilterBaseModel _LaChuGroupFilter;
        HeaderFilterBaseModel _MaFilter;
        HeaderFilterBaseModel _MaGroupFilter;
        HeaderFilterBaseModel _MaUserFilter;

        public UserGroupViewModel() : base()
        {
            _LaChuGroupFilter = new HeaderCheckFilterModel(TextManager.UserGroup_LaChuGroup, nameof(UserGroupDto.LaChuGroup), typeof(bool));

            _MaFilter = new HeaderTextFilterModel(TextManager.UserGroup_Ma, nameof(UserGroupDto.Ma), typeof(int));

            _MaGroupFilter = new HeaderComboBoxFilterModel(
                TextManager.UserGroup_MaGroup, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(UserGroupDto.MaGroup),
                typeof(int),
                nameof(GroupDto.TenHienThi),
                nameof(GroupDto.Ma))
            {
                AddCommand = new SimpleCommand("MaGroupAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.GroupView(), "Group", ReferenceDataManager<GroupDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<GroupDto>.Instance.Get()
            };

            _MaUserFilter = new HeaderComboBoxFilterModel(
                TextManager.UserGroup_MaUser, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(UserGroupDto.MaUser),
                typeof(int),
                nameof(UserDto.TenHienThi),
                nameof(UserDto.Ma))
            {
                AddCommand = new SimpleCommand("MaUserAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.UserView(), "User", ReferenceDataManager<UserDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<UserDto>.Instance.Get()
            };

            InitFilterPartial();

            AddHeaderFilter(_LaChuGroupFilter);
            AddHeaderFilter(_MaFilter);
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
            if (_LaChuGroupFilter.FilterValue != null)
            {
                dto.LaChuGroup = (bool)_LaChuGroupFilter.FilterValue;
            }
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
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
