using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using System.Windows;

namespace Client.ViewModel
{
    public class RChanhViewModel : Abstraction.BaseViewModel<DTO.RChanhDto>
    {
        private HeaderComboBoxFilterModel _baiXeFilter;

        public RChanhViewModel(Abstraction.IDataService<DTO.RChanhDto> dataService)
            : base(dataService)
        {
            _baiXeFilter = new HeaderComboBoxFilterModel(
                "Bai Xe", HeaderComboBoxFilterModel.ComboBoxFilter, "MaBaiXe", typeof(int));
            _baiXeFilter.AddCommand = new SimpleCommand("BaiXeAddCommand",
                () => { ProccessHeaderAddCommand("RBaiXeView", "Bai Xe"); },
                () => true
            );
            _baiXeFilter.ItemSource = ReferenceDataManager.Instance.BaiXes();

            HeaderFilters.Add(new HeaderTextFilterModel("Ma", "Ma", typeof(int)));
            HeaderFilters.Add(_baiXeFilter);
            HeaderFilters.Add(new HeaderTextFilterModel("Ten Chanh", "TenChanh", typeof(string)));

            foreach (var filter in HeaderFilters)
            {
                filter.ActionFilterValueChanged = Load;
                filter.ActionIsUsedChanged = Load;
            }

            ReferenceDataManager.Instance.LoadBaiXes();
        }

        void ProccessHeaderAddCommand(string viewName, string title)
        {
            var viewType = System.Type.GetType("Client.View." + viewName);
            var w = new Window()
            {
                Title = title,
                FontSize = Settings.Instance.FontSize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Content = System.Activator.CreateInstance(viewType)
            };
            w.ShowDialog();

            ReferenceDataManager.Instance.LoadBaiXes();
        }

        protected override void ProcessDtoBeforeAddToEntities(RChanhDto dto)
        {
            dto.BaiXes = ReferenceDataManager.Instance.BaiXes();
        }

        protected override void ProcessNewAddedDto(RChanhDto dto)
        {
            if (_baiXeFilter.FilterValue != null)
            {
                dto.MaBaiXe = (int)_baiXeFilter.FilterValue;
            }
            dto.BaiXes = ReferenceDataManager.Instance.BaiXes();
        }
    }
}
