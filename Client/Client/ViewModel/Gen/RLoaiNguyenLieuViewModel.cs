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

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenLoaiFilter;

        public RLoaiNguyenLieuViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RLoaiNguyenLieu_ID, nameof(RLoaiNguyenLieuDto.ID), typeof(int));

            _TenLoaiFilter = new HeaderTextFilterModel(TextManager.RLoaiNguyenLieu_TenLoai, nameof(RLoaiNguyenLieuDto.TenLoai), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenLoaiFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RLoaiNguyenLieuDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RLoaiNguyenLieuDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
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
