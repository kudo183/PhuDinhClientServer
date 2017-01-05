using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChiTietToaHangController : SwaEntityBaseController<PhuDinhServerContext, TChiTietToaHang, TChiTietToaHangDto>
    {
        partial void ConvertToDtoPartial(ref TChiTietToaHangDto dto, TChiTietToaHang entity)
        {
            dto.TToaHang = new TToaHangDto();
            dto.TToaHang.MaKhachHang = entity.MaToaHangNavigation.MaKhachHang;
            dto.TToaHang.Ngay = entity.MaToaHangNavigation.Ngay;
            dto.TChiTietDonHang = new TChiTietDonHangDto();
            dto.TChiTietDonHang.ID = entity.MaChiTietDonHangNavigation.ID;
            dto.TChiTietDonHang.MaMatHang = entity.MaChiTietDonHangNavigation.MaMatHang;
            dto.TChiTietDonHang.SoLuong = entity.MaChiTietDonHangNavigation.SoLuong;
            dto.TChiTietDonHang.TDonHang = new TDonHangDto();
            dto.TChiTietDonHang.TDonHang.MaKhachHang = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.MaKhachHang;
            dto.TChiTietDonHang.TDonHang.MaKhoHang = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.MaKhoHang;
            dto.TChiTietDonHang.TDonHang.Ngay = entity.MaChiTietDonHangNavigation.MaDonHangNavigation.Ngay;
        }

        protected override IQueryable<TChiTietToaHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaToaHangNavigation.MaKhachHangNavigation)
                .Include(p => p.MaChiTietDonHangNavigation.MaDonHangNavigation)
                .Include(p => p.MaChiTietDonHangNavigation.MaMatHangNavigation);
        }
        protected override void AfterSave()
        {
            //because sql trigger updated SoTien of TCongNoKhachHang
            TCongNoKhachHangController.IncreaseVersionNumber();
            //because Toa hang include ChiTietToaHang
            TToaHangController.IncreaseVersionNumber();
        }

        protected override void UpdateEntity(PhuDinhServerContext context, TChiTietToaHang entity)
        {
            var entry = context.TChiTietToaHang.Attach(entity);
            entry.Property(p => p.MaChiTietDonHang).IsModified = true;
            entry.Property(p => p.GiaTien).IsModified = true;
        }
    }
}
