using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;
using System.Text;

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
                dto.TNhapHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetByID(dto.TNhapHang.MaKhoHang);
                dto.TNhapHang.RNhaCungCap = ReferenceDataManager<RNhaCungCapDto>.Instance.GetByID(dto.TNhapHang.MaNhaCungCap);
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
