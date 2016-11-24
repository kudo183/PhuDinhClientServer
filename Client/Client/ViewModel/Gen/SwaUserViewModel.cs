using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class SwaUserViewModel : BaseViewModel<SwaUserDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(SwaUserDto dto);
        partial void ProcessNewAddedDtoPartial(SwaUserDto dto);

        HeaderFilterBaseModel _CreateDateFilter;
        HeaderFilterBaseModel _EmailFilter;
        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _PasswordHashFilter;

        public SwaUserViewModel() : base()
        {
            _CreateDateFilter = new HeaderDateFilterModel(TextManager.SwaUser_CreateDate, nameof(SwaUserDto.CreateDate), typeof(System.DateTime));

            _EmailFilter = new HeaderTextFilterModel(TextManager.SwaUser_Email, nameof(SwaUserDto.Email), typeof(string));

            _IDFilter = new HeaderTextFilterModel(TextManager.SwaUser_ID, nameof(SwaUserDto.ID), typeof(int));

            _PasswordHashFilter = new HeaderTextFilterModel(TextManager.SwaUser_PasswordHash, nameof(SwaUserDto.PasswordHash), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_CreateDateFilter);
            AddHeaderFilter(_EmailFilter);
            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_PasswordHashFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(SwaUserDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(SwaUserDto dto)
        {
            if (_CreateDateFilter.FilterValue != null)
            {
                dto.CreateDate = (System.DateTime)_CreateDateFilter.FilterValue;
            }
            if (_EmailFilter.FilterValue != null)
            {
                dto.Email = (string)_EmailFilter.FilterValue;
            }
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
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
