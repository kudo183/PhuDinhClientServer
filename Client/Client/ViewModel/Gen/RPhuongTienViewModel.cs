using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RPhuongTienViewModel : BaseViewModel<RPhuongTienDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RPhuongTienDto dto);
        partial void ProcessNewAddedDtoPartial(RPhuongTienDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _TenPhuongTienFilter;

        public RPhuongTienViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RPhuongTien_Ma, nameof(RPhuongTienDto.Ma), typeof(int));
            _TenPhuongTienFilter = new HeaderTextFilterModel(TextManager.RPhuongTien_TenPhuongTien, nameof(RPhuongTienDto.TenPhuongTien), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenPhuongTienFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RPhuongTienDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RPhuongTienDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
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
