using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;
using System.Text;

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
                dto.TChuyenKho.RKhoHangXuat = ReferenceDataManager<RKhoHangDto>.Instance.GetByID(dto.TChuyenKho.MaKhoHangXuat);
                dto.TChuyenKho.RKhoHangNhap = ReferenceDataManager<RKhoHangDto>.Instance.GetByID(dto.TChuyenKho.MaKhoHangNhap);
            }
        }

        protected override void AfterLoad()
        {
            var tongSoKg = 0;
            var sb = new StringBuilder();
            sb.Append(", ");
            foreach (var item in Entities)
            {
                item.TMatHang = ReferenceDataManager<TMatHangDto>.Instance.GetByID(item.MaMatHang);
                if (item.TMatHang == null)
                    continue;

                if (item.TMatHang.SoKy == 0)
                {
                    sb.Append(item.TMatHang.TenMatHang);
                    sb.Append(", ");
                }
                else
                {
                    tongSoKg += item.SoLuong * item.TMatHang.SoKy;
                }
            }

            tongSoKg = tongSoKg / 10;

            Msg = string.Format("Tong trong luong: {0:N0} kg{1}", tongSoKg, sb.ToString(0, sb.Length - 2));
        }
    }
}
