using SimpleDataGrid.ViewModel;
using DTO;
using SimpleDataGrid;
using Client.Abstraction;
using System.Linq;

namespace Client.ViewModel
{
    public partial class RMatHangNguyenLieuViewModel : BaseViewModel<RMatHangNguyenLieuDto>
    {
        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Load();
            foreach (var item in ReferenceDataManager<RNguyenLieuDto>.Instance.Get())
            {
                item.RLoaiNguyenLieu = ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.GetList().Find(p => p.Ma == item.MaLoaiNguyenLieu);
            }
        }
    }
}
