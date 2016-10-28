using Client;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class RBaiXeViewModel : BaseViewModel<RBaiXeDto>
    {
        partial void InitFilterPartial();
        partial void ProcessDtoBeforeAddToEntitiesPartial(RBaiXeDto dto);
        partial void ProcessNewAddedDtoPartial(RBaiXeDto dto);

        HeaderTextFilterModel _MaFilter;
        HeaderTextFilterModel _DiaDiemBaiXeFilter;

        public RBaiXeViewModel() : base()
        {
            _MaFilter = new HeaderTextFilterModel(TextManager.RBaiXe_Ma, nameof(RBaiXeDto.Ma), typeof(int));
            _DiaDiemBaiXeFilter = new HeaderTextFilterModel(TextManager.RBaiXe_DiaDiemBaiXe, nameof(RBaiXeDto.DiaDiemBaiXe), typeof(string));

            InitFilterPartial();

            AddHeaderFilter(_MaFilter);
            AddHeaderFilter(_DiaDiemBaiXeFilter);
        }

        protected override void ProcessDtoBeforeAddToEntities(RBaiXeDto dto)
        {

            ProcessDtoBeforeAddToEntitiesPartial(dto);
        }

        protected override void ProcessNewAddedDto(RBaiXeDto dto)
        {
            if (_MaFilter.FilterValue != null)
            {
                dto.Ma = (int)_MaFilter.FilterValue;
            }
            if (_DiaDiemBaiXeFilter.FilterValue != null)
            {
                dto.DiaDiemBaiXe = (string)_DiaDiemBaiXeFilter.FilterValue;
            }

            ProcessNewAddedDtoPartial(dto);
            ProcessDtoBeforeAddToEntities(dto);
        }
    }
}
