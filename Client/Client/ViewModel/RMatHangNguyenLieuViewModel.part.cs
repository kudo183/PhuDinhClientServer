using DTO;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class RMatHangNguyenLieuViewModel : BaseViewModel<RMatHangNguyenLieuDto>
    {
        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.Load();
            foreach (var item in ReferenceDataManager<RNguyenLieuDto>.Instance.Get())
            {
                item.RLoaiNguyenLieu = ReferenceDataManager<RLoaiNguyenLieuDto>.Instance.GetByID(item.MaLoaiNguyenLieu);
            }
        }
    }
}
