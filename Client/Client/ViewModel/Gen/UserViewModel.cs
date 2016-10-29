using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class UserViewModel : BaseViewModel<UserDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(UserDto dto);
        partial void ProcessNewAddedDtoPartial(UserDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _EmailFilter;
        HeaderDateFilterModel _NgayTaoFilter;
        HeaderTextFilterModel _PasswordHashFilter;

        public UserViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.User_Ma, nameof(UserDto.Ma), typeof(int));

            _EmailFilter = new HeaderTextFilterModel(TextManager.User_Email, nameof(UserDto.Email), typeof(string));

            _NgayTaoFilter = new HeaderDateFilterModel(TextManager.User_NgayTao, nameof(UserDto.NgayTao), typeof(System.DateTime));

            _PasswordHashFilter = new HeaderTextFilterModel(TextManager.User_PasswordHash, nameof(UserDto.PasswordHash), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_EmailFilter);
            AddHeaderFilter(_NgayTaoFilter);
            AddHeaderFilter(_PasswordHashFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(UserDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(UserDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_EmailFilter.FilterValue != null)
            {
                dto.Email = (string)_EmailFilter.FilterValue;
            }
            if (_NgayTaoFilter.FilterValue != null)
            {
                dto.NgayTao = (System.DateTime)_NgayTaoFilter.FilterValue;
            }
            if (_PasswordHashFilter.FilterValue != null)
            {
                dto.PasswordHash = (string)_PasswordHashFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
