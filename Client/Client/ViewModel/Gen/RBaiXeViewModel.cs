using Client.Abstraction;
using DTO;
using SimpleDataGrid;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RBaiXeViewModel : BaseViewModel<RBaiXeDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RBaiXeDto dto);
        partial void ProcessNewAddedDtoPartial(RBaiXeDto dto);

        HeaderFilterBaseModel _DiaDiemBaiXeFilter;
        HeaderFilterBaseModel _IDFilter;

        public RBaiXeViewModel() : base()
        {
            _DiaDiemBaiXeFilter = new HeaderTextFilterModel(TextManager.RBaiXe_DiaDiemBaiXe, nameof(RBaiXeDto.DiaDiemBaiXe), typeof(string));

            _IDFilter = new HeaderTextFilterModel(TextManager.RBaiXe_ID, nameof(RBaiXeDto.ID), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_DiaDiemBaiXeFilter);
            AddHeaderFilter(_IDFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RBaiXeDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RBaiXeDto dto)
        {
            if (_DiaDiemBaiXeFilter.FilterValue != null)
            {
                dto.DiaDiemBaiXe = (string)_DiaDiemBaiXeFilter.FilterValue;
            }
            if (_IDFilter.FilterValue != null)
            {
                dto.ID = (int)_IDFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
