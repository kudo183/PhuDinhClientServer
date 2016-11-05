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
        HeaderFilterBaseModel _MaFilter;

        public RBaiXeViewModel() : base()
        {
            _DiaDiemBaiXeFilter = new HeaderTextFilterModel(TextManager.RBaiXe_DiaDiemBaiXe, nameof(RBaiXeDto.DiaDiemBaiXe), typeof(string));

            _MaFilter = new HeaderTextFilterModel(TextManager.RBaiXe_Ma, nameof(RBaiXeDto.Ma), typeof(int));

            InitFilterPartial();

            AddHeaderFilter(_DiaDiemBaiXeFilter);
            AddHeaderFilter(_MaFilter);
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
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
