using DTO;
using Client.Abstraction;

namespace Client.ViewModel
{
    public partial class TNhapNguyenLieuViewModel : BaseViewModel<TNhapNguyenLieuDto>
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
