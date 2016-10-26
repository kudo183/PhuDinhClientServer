using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RChanhViewModel : BaseViewModel<RChanhDto>
    {
        partial void InitFilterPartial()
        {
            _baiXeFilter = new HeaderComboBoxFilterModel(
                "Bai Xe", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RChanhDto.MaBaiXe), typeof(int), nameof(RBaiXeDto.DiaDiemBaiXe), nameof(RBaiXeDto.Ma));
            _baiXeFilter.AddCommand = new SimpleCommand("BaiXeAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RBaiXeView(), "Bai Xe", ReferenceDataManager<RBaiXeDto>.Instance.Load)
            );
            _baiXeFilter.ItemSource = ReferenceDataManager<RBaiXeDto>.Instance.Get();
        }
    }
}
