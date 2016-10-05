using SimpleDataGrid.ViewModel;
using System.Collections.Generic;
using DTO;
using SimpleDataGrid;
using System.Linq;

namespace Client.ViewModel
{
    public class RChanhViewModel : Abstraction.BaseViewModel<DTO.RChanhDto>
    {
        private HeaderComboBoxFilterModel _baiXeFilter;

        public RChanhViewModel(Abstraction.IDataService<DTO.RChanhDto> dataService)
            : base("RChanhViewModel", dataService)
        {
            _baiXeFilter = new HeaderComboBoxFilterModel(
                "Bai Xe", HeaderComboBoxFilterModel.ComboBoxFilter, "MaBaiXe", typeof(int));
            _baiXeFilter.AddCommand = new SimpleCommand("BaiXeAddCommand",
                () => { AddBaiXe(); },
                () => true
            );
            _baiXeFilter.ItemSource = ReferenceDataManager.Instance.BaiXes()
                .ToDictionary(p => p.Ma, p => p.DiaDiemBaiXe);

            HeaderFilters.Add(new HeaderTextFilterModel("Ma", "Ma", typeof(int)));
            HeaderFilters.Add(_baiXeFilter);
            HeaderFilters.Add(new HeaderTextFilterModel("Ten Chanh", "TenChanh", typeof(string)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }
        }

        void AddBaiXe()
        {

        }

        protected override void ProcessDtoBeforeAddToEntities(RChanhDto dto)
        {
            dto.BaiXes = new List<RBaiXeDto>(ReferenceDataManager.Instance.BaiXes());
        }

        protected override void ProcessNewAddedDto(RChanhDto dto)
        {
            dto.BaiXes = new List<RBaiXeDto>(ReferenceDataManager.Instance.BaiXes());
        }
    }
}
