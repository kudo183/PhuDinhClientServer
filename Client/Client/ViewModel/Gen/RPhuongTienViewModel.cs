using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RPhuongTienViewModel : BaseViewModel<RPhuongTienDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RPhuongTienDto dto);
        partial void ProcessNewAddedDtoPartial(RPhuongTienDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenPhuongTienFilter;

        public RPhuongTienViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RPhuongTien_ID, nameof(RPhuongTienDto.ID), typeof(int));

            _TenPhuongTienFilter = new HeaderTextFilterModel(TextManager.RPhuongTien_TenPhuongTien, nameof(RPhuongTienDto.TenPhuongTien), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenPhuongTienFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RPhuongTienDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RPhuongTienDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenPhuongTienFilter.FilterValue != null)
            {
                dto.TenPhuongTien = (string)_TenPhuongTienFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
