using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RLoaiNguyenLieuViewModel : BaseViewModel<RLoaiNguyenLieuDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RLoaiNguyenLieuDto dto);
        partial void ProcessNewAddedDtoPartial(RLoaiNguyenLieuDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _TenLoaiFilter;

        public RLoaiNguyenLieuViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RLoaiNguyenLieu_Ma, nameof(RLoaiNguyenLieuDto.Ma), typeof(int));

            _TenLoaiFilter = new HeaderTextFilterModel(TextManager.RLoaiNguyenLieu_TenLoai, nameof(RLoaiNguyenLieuDto.TenLoai), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_TenLoaiFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RLoaiNguyenLieuDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RLoaiNguyenLieuDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_TenLoaiFilter.FilterValue != null)
            {
                dto.TenLoai = (string)_TenLoaiFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
