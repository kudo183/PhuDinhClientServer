using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RLoaiChiPhiViewModel : BaseViewModel<RLoaiChiPhiDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RLoaiChiPhiDto dto);
        partial void ProcessNewAddedDtoPartial(RLoaiChiPhiDto dto);

        HeaderFilterBaseModel _IDFilter;
        HeaderFilterBaseModel _TenLoaiChiPhiFilter;

        public RLoaiChiPhiViewModel() : base()
        {
            _IDFilter = new HeaderTextFilterModel(TextManager.RLoaiChiPhi_ID, nameof(RLoaiChiPhiDto.ID), typeof(int));

            _TenLoaiChiPhiFilter = new HeaderTextFilterModel(TextManager.RLoaiChiPhi_TenLoaiChiPhi, nameof(RLoaiChiPhiDto.TenLoaiChiPhi), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_IDFilter);
            AddHeaderFilter(_TenLoaiChiPhiFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RLoaiChiPhiDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RLoaiChiPhiDto dto)
        {
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }
            if (_TenLoaiChiPhiFilter.FilterValue != null)
            {
                dto.TenLoaiChiPhi = (string)_TenLoaiChiPhiFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
