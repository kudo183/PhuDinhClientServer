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
            _MaBaiXeFilter = new HeaderComboBoxFilterModel(
                "Bai Xe", HeaderComboBoxFilterModel.ComboBoxFilter,
                nameof(RChanhDto.MaBaiXe), typeof(int), nameof(RBaiXeDto.DiaDiemBaiXe), nameof(RBaiXeDto.Ma));
            _MaBaiXeFilter.AddCommand = new SimpleCommand("BaiXeAddCommand",
                () => base.ProccessHeaderAddCommand(
                new View.RBaiXeView(), "Bai Xe", ReferenceDataManager<RBaiXeDto>.Instance.Load)
            );
            _MaBaiXeFilter.ItemSource = ReferenceDataManager<RBaiXeDto>.Instance.Get();
        }
    }
}
