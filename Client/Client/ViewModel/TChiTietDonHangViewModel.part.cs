using System;
using Client.Abstraction;
using DTO;
using SimpleDataGrid.ViewModel;
using System.Text;

namespace Client.ViewModel
{
    public partial class TChiTietDonHangViewModel : BaseViewModel<TChiTietDonHangDto>
    {
        partial void InitFilterPartial()
        {
            _MaDonHangFilter = new HeaderTextFilterModel(TextManager.TChiTietDonHang_MaDonHang, nameof(TChiTietDonHangDto.MaDonHang), typeof(int));
        }

        partial void LoadReferenceDataPartial()
        {
            ReferenceDataManager<RKhoHangDto>.Instance.Load();
            ReferenceDataManager<RKhachHangDto>.Instance.Load();
        }

        partial void ProcessDtoBeforeAddToEntitiesPartial(TChiTietDonHangDto dto)
        {
            if (dto.TDonHang != null)
            {
                dto.TDonHang.RKhoHang = ReferenceDataManager<RKhoHangDto>.Instance.GetList().Find(p => p.ID == dto.TDonHang.MaKhoHang);
                dto.TDonHang.RKhachHang = ReferenceDataManager<RKhachHangDto>.Instance.GetList().Find(p => p.ID == dto.TDonHang.MaKhachHang);
            }
        }

        partial void ProcessNewAddedDtoPartial(TChiTietDonHangDto dto)
        {
            dto.Xong = false;
        }

        protected override void AfterLoad()
        {
            var tongSoKg = 0;
            var sb = new StringBuilder();
            sb.Append(", ");
            foreach (var item in Entities)
            {
                item.TMatHang = ReferenceDataManager<TMatHangDto>.Instance.GetList().Find(p => p.Ma == item.MaMatHang);
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
