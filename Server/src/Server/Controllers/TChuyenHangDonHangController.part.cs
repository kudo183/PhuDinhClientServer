using huypq.SwaMiddleware;
using Server.Entities;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Controllers
{
    public partial class TChuyenHangDonHangController : SwaEntityBaseController<PhuDinhServerContext, TChuyenHangDonHang, TChuyenHangDonHangDto>
    {
        partial void ConvertToDtoPartial(ref TChuyenHangDonHangDto dto, TChuyenHangDonHang entity)
        {
            dto.TChuyenHang = new TChuyenHangDto();
            dto.TChuyenHang.MaNhanVienGiaoHang = entity.MaChuyenHangNavigation.MaNhanVienGiaoHang;
            dto.TChuyenHang.Ngay = entity.MaChuyenHangNavigation.Ngay;
            dto.TChuyenHang.Gio = entity.MaChuyenHangNavigation.Gio;
            dto.TDonHang = new TDonHangDto();
            dto.TDonHang.ID = entity.MaDonHangNavigation.ID;
            dto.TDonHang.MaKhachHang = entity.MaDonHangNavigation.MaKhachHang;
            dto.TDonHang.MaKhoHang = entity.MaDonHangNavigation.MaKhoHang;
            dto.TDonHang.Ngay = entity.MaDonHangNavigation.Ngay;
            dto.TDonHang.Xong = entity.MaDonHangNavigation.Xong;
        }

        protected override IQueryable<TChuyenHangDonHang> GetQuery()
        {
            var q = base.GetQuery();
            return q.Include(p => p.MaChuyenHangNavigation).Include(p => p.MaDonHangNavigation);
        }

        protected override void AfterSave()
        {
            //because sql trigger updated TongDonHang, TongSoLuongTheoDonHang of TChuyenHang
            TChuyenHangController.IncreaseVersionNumber(TokenModel.GroupId);
        }

        protected override void UpdateEntity(PhuDinhServerContext context, TChuyenHangDonHang entity)
        {
            var entry = context.TChuyenHangDonHang.Attach(entity);
            entry.Property(p => p.MaDonHang).IsModified = true;
        }
    }
}
