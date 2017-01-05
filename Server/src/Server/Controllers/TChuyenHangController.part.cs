using huypq.SwaMiddleware;
using Server.Entities;
using DTO;

namespace Server.Controllers
{
    public partial class TChuyenHangController : SwaEntityBaseController<PhuDinhServerContext, TChuyenHang, TChuyenHangDto>
    {
        protected override void UpdateEntity(PhuDinhServerContext context, TChuyenHang entity)
        {
            var entry = context.TChuyenHang.Attach(entity);
            entry.Property(p => p.Ngay).IsModified = true;
            entry.Property(p => p.Gio).IsModified = true;
            entry.Property(p => p.MaNhanVienGiaoHang).IsModified = true;
        }
    }
}
