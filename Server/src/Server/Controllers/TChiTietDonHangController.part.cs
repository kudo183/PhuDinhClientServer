using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChiTietDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietDonHang, TChiTietDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietDonHangDto dto, TChiTietDonHang entity)
        {
            dto.TDonHang = new TDonHangDto();
            dto.TDonHang.MaKhoHang = entity.MaDonHangNavigation.MaKhoHang;
            dto.TDonHang.MaKhachHang = entity.MaDonHangNavigation.MaKhachHang;
            dto.TDonHang.Ngay = entity.MaDonHangNavigation.Ngay;
        }

        protected override IQueryable<TChiTietDonHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaDonHangNavigation);
        }

        protected override void AfterSave()
        {
            //because sql trigger updated SoLuong of TTonKho
            TTonKhoController.IncreaseVersionNumber();
            //because sql trigger updated TongSoLuong, Xong of TDonHang
            TDonHangController.IncreaseVersionNumber();
            //because sql trigger updated TongSoLuongTheoDonHang of TChuyenHang
            TChuyenHangController.IncreaseVersionNumber();
            //because sql trigger updated TongSoLuongTheoDonHang of TChuyenHangDonHang
            TChuyenHangDonHangController.IncreaseVersionNumber();
            //because sql trigger updated SoLuongTheoDonHang of TChiTietChuyenHangDonHang
            TChiTietChuyenHangDonHangController.IncreaseVersionNumber();
            //because sql trigger updated SoTien of TCongNoKhachHang
            TCongNoKhachHangController.IncreaseVersionNumber();
            //because Toa hang include ChiTietDonHang
            TToaHangController.IncreaseVersionNumber();
        }
    }
}
