using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietNhapHangViewModel : BaseViewModel<TChiTietNhapHangDto>
    {
        partial void InitFilterPartial()
        {
            _MaNhapHangFilter = new HeaderTextFilterModel(TextManager.TChiTietNhapHang_MaNhapHang, nameof(TChiTietNhapHangDto.MaNhapHang), typeof(int));
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RNhaCungCapDto>.Instance.Load();
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietNhapHangDto dto)
        {
            if (dto.TNhapHang != null)
            {
                dto.TNhapHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.ID == dto.TNhapHang.MaKhoHang);
                dto.TNhapHang.RNhaCungCap = ReferenceDataManager<RNhaCungCapDto>.Instance.GetList().Find(p => p.ID == dto.TNhapHang.MaNhaCungCap);
            }
        }
    }
}
