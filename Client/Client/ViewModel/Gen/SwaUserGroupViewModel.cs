using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class SwaUserGroupViewModel : BaseViewModel<SwaUserGroupDto>
    {
        partial void InitFilterPartial();
        partial void LoadReferenceDataPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(SwaUserGroupDto dto);
        partial void ProcessNewAddedDtoPartial(SwaUserGroupDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _IsGroupOwnerFilter;
        HeaderFilterBaseModel _UserIDFilter;

        public SwaUserGroupViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.SwaUserGroup_ID, nameof(SwaUserGroupDto.ID), typeof(int));

            _IsGroupOwnerFilter = new HeaderCheckFilterModel(TextManager.SwaUserGroup_IsGroupOwner, nameof(SwaUserGroupDto.IsGroupOwner), typeof(bool));

            _UserIDFilter = new HeaderComboBoxFilterModel(
                TextManager.SwaUserGroup_UserID, HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(SwaUserGroupDto.UserID),
                typeof(int),
                nameof(SwaUserDto.TenHienThi),
                nameof(SwaUserDto.ID))
            {
                AddCommand = new SimpleCommand("UserIDAddCommand",
                    () => base.ProccessHeaderAddCommand(
                    new View.SwaUserView(), "SwaUser", ReferenceDataManager<SwaUserDto>.Instance.Load)),
                ItemSource = ReferenceDataManager<SwaUserDto>.Instance.Get()
            };

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_IsGroupOwnerFilter);
            AddHeaderFilter(_UserIDFilter);
        }

        public override void LoadReferenceData()
        {
            ReferenceDataManager<SwaUserDto>.Instance.Load();

            LoadReferenceDataPartial();
        }

        protected override void ProcessDtoBeforeAddToEntities(SwaUserGroupDto dto)
        {
            dto.UserIDSources = ReferenceDataManager<SwaUserDto>.Instance.Get();

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(SwaUserGroupDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_IsGroupOwnerFilter.FilterValue != null)
            {
                dto.IsGroupOwner = (bool)_IsGroupOwnerFilter.FilterValue;
            }
            if (_UserIDFilter.FilterValue != null)
            {
                dto.UserID = (int)_UserIDFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
