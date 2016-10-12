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
                "MaBaiXe", typeof(int), "DiaDiemBaiXe", "Ma");
            _baiXeFilter.AddCommand = new SimpleCommand("BaiXeAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RBaiXeView(), "Bai Xe", ReferenceDataManager<RBaiXeDto>.Instance.Load)
            );
            _baiXeFilter.ItemSource = ReferenceDataManager<RBaiXeDto>.Instance.Get();

            HeaderFilters.Add(new HeaderTextFilterModel("Ma", "Ma", typeof(int)));
            HeaderFilters.Add(_baiXeFilter);
            HeaderFilters.Add(new HeaderTextFilterModel("Ten Chanh", "TenChanh", typeof(string)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
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
