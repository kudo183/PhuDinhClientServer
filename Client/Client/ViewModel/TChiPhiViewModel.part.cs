using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;
using System.Linq;

namespace Client.ViewModel
{
    public partial class TChiPhiViewModel : BaseViewModel<TChiPhiDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = HeaderFilterBaseModel.SortDirection.Descending;
        }

        protected override void AfterLoad()
        {
            Msg = string.Format("Tong so tien: {0:N0}", Entities.Sum(p => p.SoTien));
        }
    }
}
