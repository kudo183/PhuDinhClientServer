using Client.Abstraction;
using DTO;
using System.Linq;

namespace Client.ViewModel
{
    public partial class TChiPhiViewModel : BaseViewModel<TChiPhiDto>
    {
        partial void InitFilterPartial()
        {
            _NgayFilter.IsSorted = false;
        }

        protected override void AfterLoad()
        {
            Msg = string.Format("Tong so tien: {0:N0}", Entities.Sum(p => p.SoTien));
        }
    }
}
