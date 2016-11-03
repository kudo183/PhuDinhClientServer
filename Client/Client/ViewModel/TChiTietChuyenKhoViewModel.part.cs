using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;

namespace Client.ViewModel
{
    public partial class TChiTietChuyenKhoViewModel : BaseViewModel<TChiTietChuyenKhoDto>
    {
        partial void InitFilterPartial()
        {
            _MaChuyenKhoFilter = new HeaderTextFilterModel(TextManager.TChiTietChuyenKho_MaChuyenKho, nameof(TChiTietChuyenKhoDto.MaChuyenKho), typeof(int));
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietChuyenKhoDto dto)
        {
            if (dto.TChuyenKho != null)
            {
                dto.TChuyenKho.RKhoHangXuat = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.Ma == dto.TChuyenKho.MaKhoHangXuat);
                dto.TChuyenKho.RKhoHangNhap = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.Ma == dto.TChuyenKho.MaKhoHangNhap);
            }
        }
    }
}
