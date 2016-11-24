using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RLoaiHangViewModel : BaseViewModel<RLoaiHangDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RLoaiHangDto dto);
        partial void ProcessNewAddedDtoPartial(RLoaiHangDto dto);

        HeaderFilterBaseModel _HangNhaLamFilter;
        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenLoaiFilter;

        public RLoaiHangViewModel() : base()
        {
            _HangNhaLamFilter = new HeaderCheckFilterModel(TextManager.RLoaiHang_HangNhaLam, nameof(RLoaiHangDto.HangNhaLam), typeof(bool));

            _IDFilter = new HeaderTextFilterModel(TextManager.RLoaiHang_ID, nameof(RLoaiHangDto.ID), typeof(int));

            _TenLoaiFilter = new HeaderTextFilterModel(TextManager.RLoaiHang_TenLoai, nameof(RLoaiHangDto.TenLoai), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_HangNhaLamFilter);
            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenLoaiFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RLoaiHangDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RLoaiHangDto dto)
        {
            if (_HangNhaLamFilter.FilterValue != null)
            {
                dto.HangNhaLam = (bool)_HangNhaLamFilter.FilterValue;
            }
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
