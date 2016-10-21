using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public class RChanhViewModel : BaseViewModel<RChanhDto>
    {
        private HeaderComboBoxFilterModel _baiXeFilter;

        public RChanhViewModel() : base()
        {
            _baiXeFilter = new HeaderComboBoxFilterModel(
                "Bai Xe", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RChanhDto.MaBaiXe), typeof(int), nameof(RBaiXeDto.DiaDiemBaiXe), nameof(RBaiXeDto.Ma));
            _baiXeFilter.AddCommand = new SimpleCommand("BaiXeAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RBaiXeView(), "Bai Xe", ReferenceDataManager<RBaiXeDto>.Instance.Load)
            );
            _baiXeFilter.ItemSource = ReferenceDataManager<RBaiXeDto>.Instance.Get();

            AddHeaderFilter(new HeaderTextFilterModel("Ma", nameof(RChanhDto.Ma), typeof(int)));
            AddHeaderFilter(_baiXeFilter);
            AddHeaderFilter(new HeaderTextFilterModel("Ten Chanh", nameof(RChanhDto.TenChanh), typeof(string)));
        }

        protected override void LoadedData(PagingResultDto<RChanhDto> data)
        {
            ReferenceDataManager<RBaiXeDto>.Instance.Load();
        }

        protected override void ProcessDtoBeforeAddToEntities(RChanhDto dto)
        {
            dto.BaiXes = ReferenceDataManager<RBaiXeDto>.Instance.Get();
        }

        protected override void ProcessNewAddedDto(RChanhDto dto)
        {
            if (_baiXeFilter.FilterValue != null)
            {
                dto.MaBaiXe = (int)_baiXeFilter.FilterValue;
            }
            dto.BaiXes = ReferenceDataManager<RBaiXeDto>.Instance.Get();
        }
    }
}
